/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 22/09/2011
 * Time: 21:53
 * 
 * User: © Mark Gravestock 
*/

using System.Windows.Forms;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	partial class DeviceConfigurationDialog
	{
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new ZoneFiveSoftware.Common.Visuals.Button();
            this.btnCancel = new ZoneFiveSoftware.Common.Visuals.Button();
            this.btnDirectoryChooser = new ZoneFiveSoftware.Common.Visuals.Button();
            this.chkImportOnlyNew = new System.Windows.Forms.CheckBox();
            this.txtImportDirectory = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.labelImportDirectory = new System.Windows.Forms.Label();
            this.cmboUserNumber = new System.Windows.Forms.ComboBox();
            this.labelUserNumber = new System.Windows.Forms.Label();
            this.importDirectoryErrorProvider = new System.Windows.Forms.ErrorProvider();
            
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.btnOk.CenterImage = null;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.HyperlinkStyle = false;
            this.btnOk.ImageMargin = 2;
            this.btnOk.LeftImage = null;
            this.btnOk.Location = new System.Drawing.Point(226, 90);
            this.btnOk.Name = "btnOk";
            this.btnOk.PushStyle = true;
            this.btnOk.RightImage = null;
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlign = System.Drawing.StringAlignment.Center;
            this.btnOk.TextLeftMargin = 2;
            this.btnOk.TextRightMargin = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.btnCancel.CenterImage = null;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.HyperlinkStyle = false;
            this.btnCancel.ImageMargin = 2;
            this.btnCancel.LeftImage = null;
            this.btnCancel.Location = new System.Drawing.Point(300, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PushStyle = true;
            this.btnCancel.RightImage = null;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.StringAlignment.Center;
            this.btnCancel.TextLeftMargin = 2;
            this.btnCancel.TextRightMargin = 2;
            // 
            // chkImportOnlyNew
            // 
            this.chkImportOnlyNew.AutoSize = true;
            this.chkImportOnlyNew.Checked = true;
            this.chkImportOnlyNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImportOnlyNew.Location = new System.Drawing.Point(15, 12);
            this.chkImportOnlyNew.Name = "chkImportOnlyNew";
            this.chkImportOnlyNew.Size = new System.Drawing.Size(124, 17);
            this.chkImportOnlyNew.TabIndex = 0;
            this.chkImportOnlyNew.Text = "Import new data only";
            this.chkImportOnlyNew.UseVisualStyleBackColor = true;
            // 
            // txtImportDirectory
            // 
            this.txtImportDirectory.AcceptsReturn = false;
            this.txtImportDirectory.AcceptsTab = false;
            this.txtImportDirectory.BackColor = System.Drawing.Color.White;
            this.txtImportDirectory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtImportDirectory.ButtonImage = null;
            this.txtImportDirectory.Location = new System.Drawing.Point(117, 37);
            this.txtImportDirectory.Multiline = false;
            this.txtImportDirectory.Name = "txtImportDirectory";
            this.txtImportDirectory.ReadOnly = true;
            this.txtImportDirectory.ReadOnlyColor = System.Drawing.SystemColors.ControlDark;
            this.txtImportDirectory.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtImportDirectory.Size = new System.Drawing.Size(180, 19);
            this.txtImportDirectory.TabIndex = 2;
            this.txtImportDirectory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelImportDirectory
            // 
            this.labelImportDirectory.Location = new System.Drawing.Point(12, 40);
            this.labelImportDirectory.Name = "labelImportDirectory";
            this.labelImportDirectory.Size = new System.Drawing.Size(150, 19);
            this.labelImportDirectory.TabIndex = 1;
            this.labelImportDirectory.Text = "PoolMate Directory:";
            // 
            // btnDirectoryChooser
            // 
            this.btnDirectoryChooser.BackColor = System.Drawing.Color.Transparent;
            this.btnDirectoryChooser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.btnDirectoryChooser.CenterImage = null;
            this.btnDirectoryChooser.HyperlinkStyle = false;
            this.btnDirectoryChooser.ImageMargin = 2;
            this.btnDirectoryChooser.LeftImage = null;
            this.btnDirectoryChooser.Location = new System.Drawing.Point(325, 37);
            this.btnDirectoryChooser.Name = "btnDirectoryChooser";
            this.btnDirectoryChooser.PushStyle = true;
            this.btnDirectoryChooser.RightImage = null;
            this.btnDirectoryChooser.Size = new System.Drawing.Size(60, 19);
            this.btnDirectoryChooser.TabIndex = 3;
            this.btnDirectoryChooser.Text = "Directory...";
            this.btnDirectoryChooser.TextAlign = System.Drawing.StringAlignment.Center;
            this.btnDirectoryChooser.TextLeftMargin = 2;
            this.btnDirectoryChooser.TextRightMargin = 2;

            this.cmboUserNumber.Name = "cmboUserNumber";
            this.cmboUserNumber.Location = new System.Drawing.Point(117, 62);
            this.cmboUserNumber.Size = new System.Drawing.Size(50, 19);
            this.cmboUserNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmboUserNumber.TabIndex = 3;
            this.cmboUserNumber.Enabled = false;
            
            // 
            // labelUserNumber
            // 
            
            this.labelUserNumber.Location = new System.Drawing.Point(12, 65);
            this.labelUserNumber.Name = "labelUserNumber";
            this.labelUserNumber.Size = new System.Drawing.Size(150, 19);
            this.labelUserNumber.TabIndex = 4;
            this.labelUserNumber.Text = "User Number:";
            
            
            // 
            // DeviceConfigurationDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 116);
            this.Controls.Add(this.txtImportDirectory);
            this.Controls.Add(this.labelImportDirectory);
			this.Controls.Add(this.cmboUserNumber);
            this.Controls.Add(this.labelUserNumber);
            this.Controls.Add(this.chkImportOnlyNew);
            this.Controls.Add(this.btnDirectoryChooser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceConfigurationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PoolMate Pro Import Settings";
            this.ResumeLayout(false);
            this.PerformLayout();
            
            this.importDirectoryErrorProvider.SetIconAlignment (this.txtImportDirectory, ErrorIconAlignment.MiddleRight);
            this.importDirectoryErrorProvider.SetIconPadding (this.txtImportDirectory, 2);
        }

        #endregion

        private ZoneFiveSoftware.Common.Visuals.Button btnOk;
        private ZoneFiveSoftware.Common.Visuals.Button btnCancel;
        private System.Windows.Forms.CheckBox chkImportOnlyNew;
        private System.Windows.Forms.Label labelImportDirectory;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtImportDirectory;
        private System.Windows.Forms.Label labelUserNumber;
        private System.Windows.Forms.ComboBox cmboUserNumber;
        private ZoneFiveSoftware.Common.Visuals.Button btnDirectoryChooser;
		private System.Windows.Forms.ErrorProvider importDirectoryErrorProvider;		
	}
}