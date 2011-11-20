/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 17/09/2011
 * Time: 23:50
 * 
 * User: © Mark Gravestock 
*/
using System;
using FileHelpers;


namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.File
{
	/// <summary>
	/// Description of LogEntry.
	/// </summary>
	/// 
	
	[DelimitedRecord(",")] 
	public class LogEntry
	{
		public int User;

		[FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
	    public DateTime LogDate; 
		
	    [FieldConverter(ConverterKind.Date, "HH:mm:ss")]
	    public DateTime LogTime;
		
		public Activity Activity;
		
		public int? PoolLength;
		
		[FieldConverter(typeof(LengthUnitConverter))]
		public LengthUnit? LengthUnit;
		
	    [FieldConverter(ConverterKind.Date, "HH:mm:ss")]
	    public DateTime TotalDuration;
		
		public int? Calories;
		public int? TotalLengths;
		public int? TotalDistance;
		public int? Nset;

	    [FieldConverter(ConverterKind.Date, "HH:mm:ss")]
	    public DateTime Duration;
		
	    public int? Strokes;
	    public int? Distance;
	    public int? Speed;
	    public int? Efficiency;
	    public int? StrokeRate;
	    public int? HRmin;
	    public int? HRmax;
	    public int? HRavg;
	    public int? HRbegin;
	    public int? HRend;
	    public int Version;
	}
}
