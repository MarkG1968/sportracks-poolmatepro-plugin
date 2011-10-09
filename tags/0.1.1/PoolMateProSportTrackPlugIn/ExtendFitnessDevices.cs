/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 17/09/2011
 * Time: 21:42
 * 
 */
using System;
using System.Collections.Generic;
using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	public class ExtendFitnessDevices : IExtendFitnessDevices
	{
		public IList<IFitnessDevice> FitnessDevices
        {
            get { return new IFitnessDevice[] { new FitnessDevice_PoolMatePro(), }; }
        }
	}
}
