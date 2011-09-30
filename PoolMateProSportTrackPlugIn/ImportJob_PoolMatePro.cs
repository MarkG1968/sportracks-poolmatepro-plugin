/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 17/09/2011
 * Time: 23:06
 * 
 * User: © Mark Gravestock
 */
using System;
using System.Collections.Generic;

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;

using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of ImportJob_PoolMatePro.
	/// </summary>
	class ImportJob_PoolMatePro
	{
		public ImportJob_PoolMatePro(string sourceDescription, DeviceConfigurationInfo configInfo, IJobMonitor monitor, IImportResults importResults)
		{
			this.sourceDescription = sourceDescription.Replace(Environment.NewLine, " ");
			this.configInfo = configInfo;
			this.monitor = monitor;
			this.importResults = importResults;
		}

		public bool Import()
		{
			try
			{
				monitor.PercentComplete = 0;
				monitor.StatusText = Properties.Resources.ImportStarting;
				
				if (PerformImport())
				{
					monitor.PercentComplete = 1;
					monitor.StatusText = Properties.Resources.ImportComplete;
				}
				else
				{
					monitor.ErrorText = Properties.Resources.NothingToImport;
					return false;
				}
			}
			catch(Exception e)
			{
				monitor.ErrorText = e.Message;
				return false;
			}

			return true;
		}

		private bool PerformImport()
		{
			PoolMateProImporter importer = new PoolMateProImporter();
			
			importer.OpenDirectory(configInfo.FileLocation);
			
			LogFile logFile = importer.LoadLatestLogFile();

			if (logFile.IsFile)
			{
				IList<LogEntry> allLogEntries = logFile.GetAllEntries();
				IList<SwimSession> allActivities = new SwimSessionFactory().CreateFrom(allLogEntries);
				List<SwimSession> activitiesToAdd = new List<SwimSession>();
				
				//TODO: Filter by User
				
				if (ShouldImportOnlyActivtiesNotAlreadyInLogBook())
				{
					activitiesToAdd.AddRange(FilterActivitiesAlreadyInLogBook(allActivities));
				}
				else
				{
					activitiesToAdd.AddRange(allActivities);
				}
				
				AddActivities(importResults, activitiesToAdd);
				
				return true;
			}
			
			return false;
		}
		
		private Boolean ShouldImportOnlyActivtiesNotAlreadyInLogBook()
		{
			return configInfo.ImportOnlyNew && PlugIn.Instance.Application != null && PlugIn.Instance.Application.Logbook != null;
		}
		
		private IList<SwimSession> FilterActivitiesAlreadyInLogBook(IList<SwimSession> entriesToFilter)
		{
			Dictionary<DateTime, SwimSession> sessionByStart = new Dictionary<DateTime, SwimSession>();
			
			foreach(SwimSession sessionToFilter in entriesToFilter)
			{
				DateTime sessionStartUtc = sessionToFilter.StartTime.ToUniversalTime();
			
				if (!sessionByStart.ContainsKey(sessionStartUtc))
				{
					sessionByStart.Add(sessionStartUtc, sessionToFilter);
				}
			}
			
			foreach (IActivity activity in PlugIn.Instance.Application.Logbook.Activities)
			{
				DateTime findTime = activity.StartTime;
				
				if (sessionByStart.ContainsKey(findTime))
				{
					sessionByStart.Remove(findTime);
				}
			}

			List<SwimSession> sessionsToAdd = new List<SwimSession>();
			
			sessionsToAdd.AddRange(sessionByStart.Values);

			return (IList<SwimSession>)sessionsToAdd;
		}
		
		private void AddActivities(IImportResults importResults, List<SwimSession> entriesToAdd)
		{
			IActivityCategory swimming = FindSwimmingActivityCategory();
			
			AddEntriesToLogBook(swimming, importResults, entriesToAdd);
		}

		void AddEntriesToLogBook(IActivityCategory swimming, IImportResults importResults, List<SwimSession> entriesToAdd)
		{
			foreach (SwimSession poolMateActivity in entriesToAdd) 
			{
				DateTime sessionTime = poolMateActivity.StartTime;
				IActivity activity = importResults.AddActivity(sessionTime);
				activity.Metadata.Source = String.Format(CommonResources.Text.Devices.ImportJob_ActivityImportSource, sourceDescription);
				
				if (swimming != null)
				{
					activity.Category = swimming;
				}
				
				activity.TotalTimeEntered = poolMateActivity.TotalTime;
				activity.TotalDistanceMetersEntered = poolMateActivity.TotalDistanceMeters;
				activity.TotalCalories = poolMateActivity.TotalCalories;
				activity.Notes = String.Format(Properties.Resources.ActivityDescription, poolMateActivity.PoolLengthDescription);
					
				DateTime lapTime = activity.StartTime;
				
				foreach (SwimSet @set in poolMateActivity.Sets) 
				{
					ILapInfo lap = activity.Laps.Add(lapTime, @set.LapTime);
					lap.TotalDistanceMeters = @set.LapDistanceMeters;
					lap.AverageCadencePerMinute = @set.StrokeRate;
					lap.Notes = String.Format(Properties.Resources.LapDescription, @set.Efficiency, @set.Strokes);
					lapTime = lapTime.Add(@set.LapTime);
				}
				
				activity.GPSRoute = null;
				activity.HeartRatePerMinuteTrack = null;
				activity.CadencePerMinuteTrack = null;
				activity.PowerWattsTrack = null;
			}
		}

		IActivityCategory FindSwimmingActivityCategory()
		{
			IActivityCategory swimming = null;
			
			FindInActivityCategories(PlugIn.Instance.Application.Logbook.ActivityCategories, ref swimming);
			
			return swimming;
		}
		
		private void FindInActivityCategories(IEnumerable<IActivityCategory> activityCategories, ref IActivityCategory swimming)
		{
			foreach (IActivityCategory activityCategory in activityCategories)
			{
				if (swimming != null)
				{
					break;
				}
				
				String swimmingActivityName = Properties.Resources.SwimmingActivityName;
				
				if (activityCategory.Name.Equals(swimmingActivityName, StringComparison.InvariantCultureIgnoreCase))
				{
					swimming = activityCategory;
					break;
				}
				
				IActivityCategoryList activitySubCategories = activityCategory.SubCategories;
				
				if (activitySubCategories != null)
				{
					FindInActivityCategories(activitySubCategories, ref swimming);
				}
			}
		}
		
		private string sourceDescription;
		private DeviceConfigurationInfo configInfo;
		private IJobMonitor monitor;
		private IImportResults importResults;
	}
}
