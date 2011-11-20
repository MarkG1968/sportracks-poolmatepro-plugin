/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 18.10.2011
 * Time: 20:59
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.Threading;
using System.Globalization;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.Utilities
{
	/// <summary>
	/// Description of ScopedLocaleSwitcher.
	/// </summary>
	public class ScopedLocaleSwitcher : IDisposable
	{
		private CultureInfo originalLocale;
		
		public ScopedLocaleSwitcher(CultureInfo targetCultureInfo)
		{
			SaveOriginalLocale();
			SwitchToLocale(targetCultureInfo);
		}
		
		public void Dispose()
		{
			RevertToOriginalLocale();
		}
		
		private void SwitchToLocale(CultureInfo targetCultureInfo)
		{
			Thread.CurrentThread.CurrentCulture = targetCultureInfo;
		}

		private void RevertToOriginalLocale()
		{
			Thread.CurrentThread.CurrentCulture = originalLocale;
		}
		
		private void SaveOriginalLocale()
		{
			originalLocale = Thread.CurrentThread.CurrentCulture;
		}
	}
}
