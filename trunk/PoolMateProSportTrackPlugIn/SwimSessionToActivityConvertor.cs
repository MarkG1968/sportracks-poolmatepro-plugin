/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 15/10/2011
 * Time: 21:36
 * 
 * User: © Mark Gravestock 
*/
using System;

using ZoneFiveSoftware.Common.Data.Fitness;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Properties;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of SwimSessionToActivityConvertor.
	/// </summary>
	public class SwimSessionToActivityConvertor
	{
		private String sourceDescription;
		private IActivityCategory swimmingCategory;
		private String activityDescription;
		private String lapDescription;
		
		internal SwimSessionToActivityConvertor(String sourceDescription, IActivityCategory swimmingCategory, String activityDescription, String lapDescription)
		{
			this.sourceDescription = sourceDescription;
			this.swimmingCategory = swimmingCategory;
			this.activityDescription = activityDescription;
			this.lapDescription = lapDescription;
		}
		
		public void AddInto(IActivityFactory activityFactory, SwimSession swimSession)
		{
			IActivity activity = activityFactory.CreateAt(swimSession.StartTime);
			
			activity.Metadata.Source = sourceDescription;
				
			if (swimmingCategory != null)
			{
				activity.Category = swimmingCategory;
			}
				
			activity.TotalTimeEntered = swimSession.TotalTime;
			activity.TotalDistanceMetersEntered = swimSession.TotalDistanceMeters;
			activity.TotalCalories = swimSession.TotalCalories;
			activity.Notes = String.Format(activityDescription, swimSession.PoolLengthDescription);
				
			DateTime lapTime = activity.StartTime;
			
			foreach (SwimSet @set in swimSession.Sets) 
			{
				ILapInfo lap = activity.Laps.Add(lapTime, @set.LapTime);
				lap.TotalDistanceMeters = @set.LapDistanceMeters;
				lap.AverageCadencePerMinute = @set.StrokeRate;
				lap.Notes = String.Format(lapDescription, @set.Efficiency, @set.Strokes);
				lapTime = lapTime.Add(@set.LapTime);
			}
			
			activity.GPSRoute = null;
			activity.HeartRatePerMinuteTrack = null;
			activity.CadencePerMinuteTrack = null;
			activity.PowerWattsTrack = null;
		}
	}
}
