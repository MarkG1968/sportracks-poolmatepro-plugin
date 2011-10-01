/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 25/09/2011
 * Time: 16:21
 * 
 * User: © Mark Gravestock 
*/
using System;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain
{
	/// <summary>
	/// Description of DistanceCalculator.
	/// </summary>
	public class LengthCalculator
	{
		public LengthCalculator()
		{
		}
		
		public static Length ToLengthInMetres(Length from)
		{
			return new LengthCalculator().ToLengthInUnit(LengthUnit.Metres, from);
		}

		public Length ToLengthInUnit(LengthUnit unit, Length from)
		{
			if (from.RequiresConversionTo(unit))
			{
				float conversionFactor = (unit == LengthUnit.Yards ? 0.9144F : 1F);
				return new Length(LengthUnit.Metres, from.Amount * conversionFactor);
			}
			else
			{
				return from;
			}
			  
		}
	}
}
