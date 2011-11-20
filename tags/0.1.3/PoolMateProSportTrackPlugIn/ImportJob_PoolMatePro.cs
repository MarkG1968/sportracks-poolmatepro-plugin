/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 17/09/2011
 * Time: 23:06
 * 
 * User: © Mark Gravestock
 */
using System;
using System.Collections.Generic;

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;

using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Properties;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Configuration;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of ImportJob_PoolMatePro.
	/// </summary>
	class ImportJob_PoolMatePro
	{
		public ImportJob_PoolMatePro(string sourceDescription, DeviceConfigurationInfo configInfo, IJobMonitor monitor, IImportResults importResults)
		{
			this.sourceDescription = sourceDescription.Replace(Environment.NewLine, " ");
			this.sourceDescription = String.Format(CommonResources.Text.Devices.ImportJob_ActivityImportSource, sourceDescription);
			this.configInfo = configInfo;
			this.monitor = monitor;
			this.importResults = importResults;
			
		}

		public bool Import()
		{
			try
			{
				monitor.PercentComplete = 0;
				monitor.StatusText = Properties.Resources.ImportStarting;
				
				if (HasLogbookToImportInto())
				{
					importer = new Importer(PlugIn.Instance.Application.Logbook, configInfo, new ResourcesAdapter(sourceDescription));

					if (importer.ImportInto(importResults))
					{
						monitor.PercentComplete = 1;
						monitor.StatusText = Properties.Resources.ImportComplete;
					}
					else
					{
						monitor.ErrorText = Properties.Resources.NothingToImport;
						return false;
					}
				}
				else
				{
					monitor.ErrorText = Properties.Resources.NoLogbookAvailable;
					return false;					
				}
			}
			catch(Exception e)
			{
				monitor.ErrorText = e.Message;
				return false;
			}

			return true;
		}

		private Boolean HasLogbookToImportInto()
		{
			return PlugIn.Instance.Application != null && PlugIn.Instance.Application.Logbook != null;
		}
				
		private string sourceDescription;
		private DeviceConfigurationInfo configInfo;
		private IJobMonitor monitor;
		private IImportResults importResults;
		private Importer importer;
	}
}
