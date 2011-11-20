/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 15/10/2011
 * Time: 20:04
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.Collections.Generic;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain
{
	/// <summary>
	/// A Filter than takes a list of SwimSessions and filters them to return a subset.
	/// </summary>
	public interface ISwimSessionFilter
	{
		IList<SwimSession> Filter(IList<SwimSession> sessionsToFilter);
	}
}
