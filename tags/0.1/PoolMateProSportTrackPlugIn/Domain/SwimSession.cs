/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 18/09/2011
 * Time: 01:09
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.Collections.Generic;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain
{
	/// <summary>
	/// Description of Activity.
	/// </summary>
	public class SwimSession
	{
		List<SwimSet> sets = new List<SwimSet>();
		SwimSet firstSet = null;
		DateTime startTime = DateTime.Today;
		
		public SwimSession(DateTime startTime, SwimSet set)
		{
			this.startTime = startTime;
			this.firstSet = set;
			
			AddSet(set);
		}
		
		public DateTime StartTime
		{
			get { return startTime; }
		}
		
		public void AddSet(SwimSet set)
		{
			sets.Add(set);
		}
		
		public int SetCount
		{
			get { return sets.Count; }
		}

		public List<SwimSet> Sets
		{
			get { return sets; }
		}
		
		public TimeSpan TotalTime
		{
			get { return firstSet.TotalTime; }
		}
		
		public String PoolLengthDescription
		{
			get { return firstSet.PoolLengthDescription; }
		}

		public float TotalDistanceMeters
		{
			get { return firstSet.TotalDistanceMeters; }
		}
		
		public float TotalCalories
		{
			get { return firstSet.Calories; }
		}

	}
}
