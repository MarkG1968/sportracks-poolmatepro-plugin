/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 15/10/2011
 * Time: 22:47
 * 
 * User: © Mark Gravestock 
*/
using System;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.Properties
{
	/// <summary>
	/// Description of IResources.
	/// </summary>
	public interface IResources
	{
		string SwimmingActivityName { get; }
		string ActivityDescription { get; }
		string LapDescription { get; }
		string SourceDescription { get; }
	}
}
