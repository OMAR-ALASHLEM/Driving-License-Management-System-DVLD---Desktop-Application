namespace DVLD_Presentation.Licenses.Local_License
{
    partial class frmIssueDriverLicenseFirstTime
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
            this.ctrlDrivingLicenseApplicationInfo1 = new DVLD_Presentation.Applications.Local_Driving_License.ctrlDrivingLicenseApplicationInfo();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIssueLicence = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            this.ctrlDrivingLicenseApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlDrivingLicenseApplicationInfo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            this.ctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(759, 410);
            this.ctrlDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(145, 428);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(539, 144);
            this.txtNotes.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label4.Image = global::DVLD_Presentation.Properties.Resources.Notes_32;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(21, 428);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 36);
            this.label4.TabIndex = 212;
            this.label4.Text = "Notes :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIssueLicence
            // 
            this.btnIssueLicence.BackColor = System.Drawing.Color.SteelBlue;
            this.btnIssueLicence.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssueLicence.FlatAppearance.BorderSize = 0;
            this.btnIssueLicence.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(179)))));
            this.btnIssueLicence.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.btnIssueLicence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueLicence.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.btnIssueLicence.ForeColor = System.Drawing.Color.White;
            this.btnIssueLicence.Image = global::DVLD_Presentation.Properties.Resources.License_Type_32;
            this.btnIssueLicence.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueLicence.Location = new System.Drawing.Point(434, 578);
            this.btnIssueLicence.Name = "btnIssueLicence";
            this.btnIssueLicence.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnIssueLicence.Size = new System.Drawing.Size(250, 55);
            this.btnIssueLicence.TabIndex = 214;
            this.btnIssueLicence.Text = "    Issue License";
            this.btnIssueLicence.UseVisualStyleBackColor = false;
            this.btnIssueLicence.Click += new System.EventHandler(this.btnIssueLicence_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnClose.Image = global::DVLD_Presentation.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(145, 578);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(251, 55);
            this.btnClose.TabIndex = 215;
            this.btnClose.Text = "      Close Window";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // frmIssueDriverLicenseFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(770, 650);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssueLicence);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmIssueDriverLicenseFirstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Driver License First Time";
            this.Load += new System.EventHandler(this.frmIssueDriverLicenseFirstTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Local_Driving_License.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnIssueLicence;
        private System.Windows.Forms.Button btnClose;
    }
}