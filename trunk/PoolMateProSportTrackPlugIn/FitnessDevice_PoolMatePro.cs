/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 17/09/2011
 * Time: 22:30
 *
*/
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;

using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	public class FitnessDevice_PoolMatePro : IFitnessDevice
	{
        public FitnessDevice_PoolMatePro()
        {
            this.id = new Guid("D10111DB-C216-4DA7-86CB-FB495689CBC1");
            this.image = Properties.Resources.Image_48_PoolMatePro;
            this.name = "PoolMate Pro";
        	this.dialog = new DeviceConfigurationDialog();
        	
            this.dialog.ValidateEventHandler += new ValidateEventHandler(ValidateImportDirectory);
        }

        public Guid Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public Image Image
        {
            get { return image; }
        }

        public string ConfiguredDescription(string configurationInfo)
        {
            return Name;
        }

        public string Configure(string configurationInfo)
        {
        	if (configurationInfo == null)
        	{
        		configurationInfo = DeviceConfigurationInfo.Default.ToString();
        	}
        	
            DeviceConfigurationInfo configInfo = DeviceConfigurationInfo.Parse(configurationInfo);
            
            dialog.ConfigurationInfo = configInfo;
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.ConfigurationInfo.ToString();
            }
            else
            {
                return null;
            }
        }
        
        public void ValidateImportDirectory(DirectoryValidationEvent directoryValidationEvent)
        {
        	PoolMateProImporter importer = new PoolMateProImporter();
			
			importer.OpenDirectory(directoryValidationEvent.DirectoryToValidate.FullName);
			
			LogFile logFile = importer.LoadLatestLogFile();

        	directoryValidationEvent.ValidationStatus = ValidationStatus.Invalid;
        }
        

        public bool Import(string configurationInfo, IJobMonitor monitor, IImportResults importResults)
        {
            ImportJob_PoolMatePro job = new ImportJob_PoolMatePro(ConfiguredDescription(configurationInfo), DeviceConfigurationInfo.Parse(configurationInfo), monitor, importResults);
            return job.Import();
        }

        #region Private members
        private Guid id;
        private Image image;
        private string name;
        private DeviceConfigurationDialog dialog;
        #endregion
    }
}
