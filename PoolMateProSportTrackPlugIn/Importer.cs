/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 15/10/2011
 * Time: 22:38
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.Collections.Generic;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals.Fitness;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Configuration;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Properties;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of Importer.
	/// </summary>
	public class Importer
	{
		private ILogbook logbook;
		private DeviceConfigurationInfo deviceConfigurationInfo;
		private IResources resources;
		
		public Importer(ILogbook logbook, DeviceConfigurationInfo deviceConfigurationInfo, IResources resources)
		{
			this.logbook = logbook;
			this.deviceConfigurationInfo = deviceConfigurationInfo;
			this.resources = resources;
		}
		
		public Boolean ImportInto(IImportResults importResults)
		{
			LogFileReader logFileReader = new LogFileReader();			
			logFileReader.OpenDirectory(deviceConfigurationInfo.FileLocation);
			LogFile logFile = logFileReader.LoadLatestLogFile();

			if (logFile.IsFile)
			{
				IList<LogEntry> allLogEntries = logFile.GetAllEntries();
				IList<SwimSession> allSwimSessions = new SwimSessionFactory().CreateFrom(allLogEntries);
				
				IList<SwimSession> candidateSwimSessionsForLogbook = new SwimSessionFilters(deviceConfigurationInfo, logbook.Activities).Filter(allSwimSessions);
								
				AddSessionsToSwimmingCategoryInLogbook(importResults, candidateSwimSessionsForLogbook);
				
				return true;
			}
			
			return false;
		}
		
		private void AddSessionsToSwimmingCategoryInLogbook(IImportResults importResults, IList<SwimSession> entriesToAdd)
		{
			AddSessionsToLogbook(FindSwimmingActivityCategory(), importResults, entriesToAdd);
		}

		void AddSessionsToLogbook(IActivityCategory swimmingCategory, IImportResults importResults, IList<SwimSession> entriesToAdd)
		{
			SwimSessionToActivityConvertor convertor = new SwimSessionToActivityConvertor(resources.SourceDescription, swimmingCategory, resources.ActivityDescription, resources.LapDescription);
			ImportResultActivityFactory activityFactory = new ImportResultActivityFactory(importResults, convertor);

			foreach (SwimSession swimSession in entriesToAdd)
			{
				activityFactory.AddActivityFor(swimSession);
			}
		}

		IActivityCategory FindSwimmingActivityCategory()
		{			
			return new ActivityCategoryFinder(logbook.ActivityCategories).Find(resources.SwimmingActivityName);
		}
	}
}
