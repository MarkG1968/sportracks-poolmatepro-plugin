/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 24/09/2011
 * Time: 21:42
 * 
 * User: © Mark Gravestock 
*/
using System;
using FileHelpers;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.File
{
	/// <summary>
	/// Description of PoolLengthUnitConverter.
	/// </summary>
	public class LengthUnitConverter : ConverterBase
	{
		public override object StringToField(string from) 
	    {
			if (from.Equals("m", StringComparison.InvariantCultureIgnoreCase))
			{
				return LengthUnit.Metres;
			}
			else if (from.Equals("yd", StringComparison.InvariantCultureIgnoreCase))
			{
				return LengthUnit.Yards;
			}
			
	      	return LengthUnit.Unknown;
	    } 
	 
	 
	    public override string FieldToString(object fieldValue) 
	    { 
	    	throw new InvalidOperationException("Not Supported");
		}
	}
}
