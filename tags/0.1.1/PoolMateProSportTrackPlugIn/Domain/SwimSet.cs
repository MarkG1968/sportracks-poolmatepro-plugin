/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 18/09/2011
 * Time: 01:10
 * 
 * User: © Mark Gravestock 
*/
using System;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain
{
	/// <summary>
	/// Description of Set.
	/// </summary>
	public class SwimSet
	{
		private LogEntry logEntry;
		
		public SwimSet(LogEntry entry)
		{
			this.logEntry = entry;	
		}

		public TimeSpan LapTime
		{
			get { return new TimeSpan(logEntry.Duration.Hour, logEntry.Duration.Minute, logEntry.Duration.Second); }
		}
		
		public float LapDistanceMeters
		{
			get { return LengthCalculator.ToLengthInMetres(new Length(logEntry.LengthUnit, logEntry.Distance)).Amount; }
		}
		
		public String PoolLengthDescription
		{
			get { return new Length(logEntry.LengthUnit, logEntry.PoolLength).ToString(); }
		}
		
		public float Calories
		{
			get { return (float)logEntry.Calories; }
		}

		public TimeSpan TotalTime
		{
			get { return new TimeSpan(logEntry.TotalDuration.Hour, logEntry.TotalDuration.Minute, logEntry.TotalDuration.Second); }
		}
		
		public float TotalDistanceMeters
		{
			get { return LengthCalculator.ToLengthInMetres(new Length(logEntry.LengthUnit, logEntry.TotalDistance)).Amount; }
		}

		public float StrokeRate
		{
			get { return (float)logEntry.StrokeRate; }
		}

		public int? Efficiency
		{
			get { return logEntry.Efficiency; }
		}

		public int? Strokes
		{
			get { return logEntry.Strokes; }
		}
	}
}
