/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 15/10/2011
 * Time: 22:56
 * 
 * User: © Mark Gravestock 
*/
using System;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.Properties
{
	/// <summary>
	/// Description of ResourcesAdapter.
	/// </summary>
	public class ResourcesAdapter : IResources
	{
		private string sourceDescription;
		
		public ResourcesAdapter(string sourceDescription)
		{
			this.sourceDescription = sourceDescription;	
		}
		
		public string SwimmingActivityName { get { return Resources.SwimmingActivityName; } }
		public string ActivityDescription { get{ return Resources.ActivityDescription; } }
		public string LapDescription { get { return Resources.LapDescription; } }
		public string SourceDescription { get { return sourceDescription; } }

	}
}
