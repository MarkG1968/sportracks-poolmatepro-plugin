/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 18/09/2011
 * Time: 01:10
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.Collections.Generic;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;
	
namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain
{
	/// <summary>
	/// Description of ActivityFactory.
	/// </summary>
	public class SwimSessionFactory
	{
		public SwimSessionFactory()
		{
		}
		
		public IList<SwimSession> CreateFrom(IList<LogEntry> entries)
		{
			IDictionary<DateTime, SwimSession> activityByStart = new Dictionary<DateTime, SwimSession>();

			foreach(LogEntry entry in entries)
			{
				if (Activity.Equals(entry.Activity, Activity.Swim))
				{
					DateTime entryDateTime = new DateTime(entry.LogDate.Year, entry.LogDate.Month, entry.LogDate.Day, entry.LogTime.Hour, entry.LogTime.Minute, entry.LogTime.Second, DateTimeKind.Local);
	
					SwimSet set = new SwimSet(entry);
					
					if (!activityByStart.ContainsKey(entryDateTime))
	                {
						activityByStart.Add(entryDateTime, new SwimSession(entryDateTime, set));
	                }
					else
					{
						activityByStart[entryDateTime].AddSet(set);
					}
				}
			}
			
			List<SwimSession> activities = new List<SwimSession>();
			activities.AddRange(activityByStart.Values);
			
			return activities;
		}
	}
}
