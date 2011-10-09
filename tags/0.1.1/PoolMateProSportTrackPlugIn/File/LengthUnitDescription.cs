/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 26/09/2011
 * Time: 19:57
 * 
 * User: © Mark Gravestock 
*/
using System;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.File
{
	/// <summary>
	/// Description of LengthUnitDescription.
	/// </summary>
	public class LengthUnitDescription
	{
		public static String AsDescription(LengthUnit unit)
		{
			return new LengthUnitDescription().ToDescription(unit);
		}
		
		public String ToDescription(LengthUnit unit)
		{
			switch(unit)
			{
				case LengthUnit.Metres:
					return Properties.Resources.LengthUnitMetres;
				case LengthUnit.Yards:
					return Properties.Resources.LengthUnitYards;
				default:
					return Properties.Resources.UnknownValue;
			}
		}

	}
}
