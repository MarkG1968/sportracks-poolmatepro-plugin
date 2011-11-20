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

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Configuration;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Configuration.Directory;

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
			dialog.DirectoryValidateEventHandler  += new DirectoryValidateEventHandler(new FitnessDevice_PoolMatePro().ValidateImportDirectory);
			dialog.ShowDialog();
			
			MessageBox.Show("Device Configuration Settings: " + dialog.ConfigurationInfo, "Results", MessageBoxButtons.OK);
		}
	}
}
