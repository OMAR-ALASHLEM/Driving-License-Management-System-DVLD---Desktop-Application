namespace DVLD_Presentation.Applications.Controls
{
    partial class ctrlApplicationBasicInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llViewPersonInfo = new System.Windows.Forms.LinkLabel();
            this.lblStatusDate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblApplicant = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llViewPersonInfo);
            this.groupBox1.Controls.Add(this.lblStatusDate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblApplicant);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCreatedByUser);
            this.groupBox1.Controls.Add(this.lblFees);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblApplicationID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(990, 376);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Basic Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // llViewPersonInfo
            // 
            this.llViewPersonInfo.AutoSize = true;
            this.llViewPersonInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llViewPersonInfo.Location = new System.Drawing.Point(738, 273);
            this.llViewPersonInfo.Name = "llViewPersonInfo";
            this.llViewPersonInfo.Size = new System.Drawing.Size(208, 32);
            this.llViewPersonInfo.TabIndex = 187;
            this.llViewPersonInfo.TabStop = true;
            this.llViewPersonInfo.Text = "View Person Info";
            this.llViewPersonInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llViewPersonInfo_LinkClicked);
            // 
            // lblStatusDate
            // 
            this.lblStatusDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatusDate.Location = new System.Drawing.Point(758, 107);
            this.lblStatusDate.Name = "lblStatusDate";
            this.lblStatusDate.Size = new System.Drawing.Size(168, 35);
            this.lblStatusDate.TabIndex = 188;
            this.lblStatusDate.Text = "[??/??/????]";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label12.Image = global::DVLD_Presentation.Properties.Resources.Calendar_32;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Location = new System.Drawing.Point(540, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(195, 35);
            this.label12.TabIndex = 190;
            this.label12.Text = "Status Date:";
            // 
            // lblType
            // 
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblType.Location = new System.Drawing.Point(216, 206);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(315, 45);
            this.lblType.TabIndex = 192;
            this.lblType.Text = "[???]";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Image = global::DVLD_Presentation.Properties.Resources.ApplicationType;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(21, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 45);
            this.label10.TabIndex = 193;
            this.label10.Text = "Type:";
            // 
            // lblApplicant
            // 
            this.lblApplicant.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblApplicant.Location = new System.Drawing.Point(216, 278);
            this.lblApplicant.Name = "lblApplicant";
            this.lblApplicant.Size = new System.Drawing.Size(450, 41);
            this.lblApplicant.TabIndex = 195;
            this.lblApplicant.Text = "[????]";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Image = global::DVLD_Presentation.Properties.Resources.Person_32;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(6, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 41);
            this.label8.TabIndex = 196;
            this.label8.Text = "Applicant:";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.Location = new System.Drawing.Point(216, 94);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(135, 35);
            this.lblStatus.TabIndex = 198;
            this.lblStatus.Text = "[???]";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Image = global::DVLD_Presentation.Properties.Resources.Number_32;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(21, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 35);
            this.label3.TabIndex = 199;
            this.label3.Text = "Status:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Image = global::DVLD_Presentation.Properties.Resources.User_32__2;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(537, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 60);
            this.label1.TabIndex = 202;
            this.label1.Text = "Created By:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCreatedByUser.Location = new System.Drawing.Point(758, 184);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(189, 35);
            this.lblCreatedByUser.TabIndex = 203;
            this.lblCreatedByUser.Text = "[????]";
            // 
            // lblFees
            // 
            this.lblFees.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFees.Location = new System.Drawing.Point(216, 142);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(112, 34);
            this.lblFees.TabIndex = 204;
            this.lblFees.Text = "[$$$]";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Image = global::DVLD_Presentation.Properties.Resources.money_32;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(22, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 34);
            this.label2.TabIndex = 205;
            this.label2.Text = "Fees:";
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.Location = new System.Drawing.Point(758, 39);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(168, 34);
            this.lblDate.TabIndex = 207;
            this.lblDate.Text = "[??/??/????]";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Image = global::DVLD_Presentation.Properties.Resources.Calendar_32;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(540, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 34);
            this.label5.TabIndex = 209;
            this.label5.Text = "Date:";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblApplicationID.Location = new System.Drawing.Point(216, 39);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(90, 34);
            this.lblApplicationID.TabIndex = 210;
            this.lblApplicationID.Text = "[???]";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Image = global::DVLD_Presentation.Properties.Resources.Number_32;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(22, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 34);
            this.label4.TabIndex = 211;
            this.label4.Text = "ID:";
            // 
            // ctrlApplicationBasicInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlApplicationBasicInfo";
            this.Size = new System.Drawing.Size(1023, 418);
            this.Load += new System.EventHandler(this.ctrlApplicationBasicInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel llViewPersonInfo;
        private System.Windows.Forms.Label lblStatusDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblApplicant;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label4;
    }
}