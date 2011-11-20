/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 15/10/2011
 * Time: 20:07
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.Collections.Generic;

using ZoneFiveSoftware.Common.Data.Fitness;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain
{
	/// <summary>
	/// Description of AlreadyImportedSwimSessionFilter.
	/// </summary>
	public class AlreadyImportedSwimSessionFilter : ISwimSessionFilter
	{
		private ILogbookActivityList logBookActivityList;
		
		public AlreadyImportedSwimSessionFilter(ILogbookActivityList logBookActivityList)
		{
			this.logBookActivityList = logBookActivityList;
		}
		
		public IList<SwimSession> Filter(IList<SwimSession> sessionsToFilter)	
		{
			return FilterActivitiesAlreadyInLogBook(sessionsToFilter);
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
	}
}
