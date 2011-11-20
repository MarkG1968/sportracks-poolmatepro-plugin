/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 15/10/2011
 * Time: 20:57
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.Collections.Generic;

using ZoneFiveSoftware.Common.Data.Fitness;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Configuration;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain
{
	/// <summary>
	/// Description of SwimSessionFilters.
	/// </summary>
	public class SwimSessionFilters : ISwimSessionFilter
	{
		private ILogbookActivityList logBookActivityList;
		private DeviceConfigurationInfo configInfo;
		
		public SwimSessionFilters(DeviceConfigurationInfo configInfo, ILogbookActivityList logBookActivityList)
		{		
			this.logBookActivityList = logBookActivityList;
			this.configInfo = configInfo;
		}

		public IList<SwimSession> Filter(IList<SwimSession> sessionsToFilter)	
		{
			List<SwimSession> candidateSwimSessionsForLogBook = new List<SwimSession>();
			
			//TODO: Filter by User

			if (ShouldImportOnlyActivtiesNotAlreadyInLogBook())
			{
				IList<SwimSession> sessionsNotInLogBook = new AlreadyImportedSwimSessionFilter(logBookActivityList).Filter(sessionsToFilter); 
				candidateSwimSessionsForLogBook.AddRange(sessionsNotInLogBook);
			}
			else
			{
				candidateSwimSessionsForLogBook.AddRange(sessionsToFilter);
			}
			
			return candidateSwimSessionsForLogBook;
		}
		
		private Boolean ShouldImportOnlyActivtiesNotAlreadyInLogBook()
		{
			return configInfo.ImportOnlyNew;
		}
	}
}
