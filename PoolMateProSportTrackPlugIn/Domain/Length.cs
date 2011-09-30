/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 25/09/2011
 * Time: 16:23
 * 
 * User: © Mark Gravestock 
*/
using System;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain
{
	/// <summary>
	/// Description of Distance.
	/// </summary>
	public class Length
	{
		private LengthUnit unit;
		private float amount;
		
		public static Length InMetres(int? amount)
		{
			return new Length(LengthUnit.Metres, amount);
		}
		
		public Length(LengthUnit? unit, int? amount) : this(unit, amount.HasValue ? (float)amount : 0F)
		{
		}

		public Length(LengthUnit? unit, float amount)
		{
			this.unit = unit.HasValue ? unit.Value : LengthUnit.Unknown;
			this.amount = amount;	
		}
		
		public float Amount { get{ return amount; } }
		
		public bool RequiresConversionTo(LengthUnit toUnit)
		{
			return unit != toUnit;
		}
		
		public override string ToString()
		{
			return string.Format("{0} {1}", amount, LengthUnitDescription.AsDescription(unit));
		}

	}
}
