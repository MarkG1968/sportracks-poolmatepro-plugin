/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 15/10/2011
 * Time: 22:00
 * 
 * User: © Mark Gravestock 
*/
using System;

using ZoneFiveSoftware.Common.Data.Fitness;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of IActivityFactory.
	/// </summary>
	public interface IActivityFactory
	{
		IActivity CreateAt(DateTime startTime);
	}
}
