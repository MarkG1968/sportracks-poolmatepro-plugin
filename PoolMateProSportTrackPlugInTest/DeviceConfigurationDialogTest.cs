/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 26/09/2011
 * Time: 06:11
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of DeviceConfigurationDialogTest.
	/// </summary>
	public class DeviceConfigurationDialogTest
	{
		public DeviceConfigurationDialogTest()
		{
			
		}
		
		[STAThread]
		public static void Main()
		{
			DeviceConfigurationDialog dialog = new DeviceConfigurationDialog();
			dialog.ConfigurationInfo = DeviceConfigurationInfo.Default;
			dialog.ValidateEventHandler  += new ValidateEventHandler(new FitnessDevice_PoolMatePro().ValidateImportDirectory);
			dialog.ShowDialog();
		}
	}
}
