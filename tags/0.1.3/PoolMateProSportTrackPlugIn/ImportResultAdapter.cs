/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 15/10/2011
 * Time: 21:52
 * 
 * User: © Mark Gravestock 
*/
using System;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals.Fitness;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of ImportResultAdapter.
	/// </summary>
	public class ImportResultActivityFactory : IActivityFactory
	{
		private IImportResults importResults;
		private SwimSessionToActivityConvertor convertor;
		
		public ImportResultActivityFactory(IImportResults importResults, SwimSessionToActivityConvertor convertor)
		{
			this.importResults = importResults;
			this.convertor = convertor;
		}
		
		public void AddActivityFor(SwimSession swimSession)
		{
			convertor.AddInto(this, swimSession);
		}

		public IActivity CreateAt(DateTime startTime)
		{
			return importResults.AddActivity(startTime);
		}
	}
}
