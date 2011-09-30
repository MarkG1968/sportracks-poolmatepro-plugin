/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 22/09/2011
 * Time: 21:53
 * 
*/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;

using ZoneFiveSoftware.Common.Visuals;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of DeviceConfigurationDialog.
	/// </summary>
	public partial class DeviceConfigurationDialog : Form
	{
        public DeviceConfigurationDialog()
        {
            InitializeComponent();

            Text = CommonResources.Text.Devices.ConfigurationDialog_Title;
            chkImportOnlyNew.Text = Properties.Resources.DeviceConfigurationDlg_chkImportOnlyNew_Text;
            labelImportDirectory.Text = Properties.Resources.DeviceConfigurationDlg_labelImportDirectory_Text;
        	btnDirectoryChooser.Text = Properties.Resources.DeviceConfigurationDlg_btnDirectoryChooser_Text;
        	labelUserNumber.Text = Properties.Resources.DeviceConfigurationDlg_labelUserNumber_Text;
        	
        	cmboUserNumber.Items.AddRange(new object[] {1,2,3});
        	
            btnOk.Text = CommonResources.Text.ActionOk;
            btnCancel.Text = CommonResources.Text.ActionCancel;

            if (PlugIn.Instance != null && PlugIn.Instance.Application != null)
            {
                ThemeChanged(PlugIn.Instance.Application.VisualTheme);
            }

            btnDirectoryChooser.Click += new EventHandler(btnDirectoryChooser_Click);
            btnOk.Click += new EventHandler(btnOk_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #region Public properties

        public DeviceConfigurationInfo ConfigurationInfo
        {
            get
            {
                DeviceConfigurationInfo configInfo = DeviceConfigurationInfo.Parse(null);
                configInfo.ImportOnlyNew = chkImportOnlyNew.Checked;
                configInfo.FileLocation = txtImportDirectory.Text;
                Int64.TryParse(cmboUserNumber.Items[cmboUserNumber.SelectedIndex].ToString(), out configInfo.UserNumber);
                return configInfo;
            }
            set
            {
                chkImportOnlyNew.Checked = value.ImportOnlyNew;
                txtImportDirectory.Text = value.FileLocation;
                int userNumberIndex = cmboUserNumber.FindString(value.UserNumber.ToString());
                cmboUserNumber.SelectedValue = value.UserNumber;
                userNumber = value.UserNumber;
            }
        }
        #endregion

        #region Public methods
        public void ThemeChanged(ITheme visualTheme)
        {
            theme = visualTheme;
            labelImportDirectory.ForeColor = visualTheme.ControlText;
            txtImportDirectory.ThemeChanged(visualTheme);
            chkImportOnlyNew.ForeColor = visualTheme.ControlText;
            BackColor = visualTheme.Control;
        }
        #endregion

        #region Event handlers
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            MessageDialog.DrawButtonRowBackground(e.Graphics, ClientRectangle, theme);
        }

        void btnDirectoryChooser_Click(object sender, EventArgs e)
        {
        	FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        	folderBrowserDialog.Description = Properties.Resources.DeviceConfigurationDialog_folderBrowserDialog_Description;
	        folderBrowserDialog.ShowNewFolderButton = false;
        	folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
        	
        	if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        	{
        		if (IsImportDirectoryValid())
        		{
        			importDirectoryErrorProvider.SetError(txtImportDirectory, String.Empty);
        			btnOk.Enabled = true;
        		}
        		else
        		{
        			importDirectoryErrorProvider.SetError(txtImportDirectory, "Invalid Dir");
        			btnOk.Enabled = false;
        		}
        		
	        	txtImportDirectory.Text = folderBrowserDialog.SelectedPath;
        	}
        }

        bool IsImportDirectoryValid()
        {
        	DirectoryValidationEvent args = new DirectoryValidationEvent(new DirectoryInfo(txtImportDirectory.Text));
        	
        	if (ValidateEventHandler != null)
        	{
        		ValidateEventHandler(args);
        		
        		if (args.ValidationStatus == ValidationStatus.Invalid)
        		{
        			return false;
        		}
        	}
        	
        	return true;
        }
        

        void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = btnOk.DialogResult;
            Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = btnCancel.DialogResult;
            Close();
        }

        #endregion

        #region Private methods

        #endregion

        public event ValidateEventHandler ValidateEventHandler;
            
        #region Private members
        private ITheme theme;
        private long userNumber;
        #endregion

    }
}
