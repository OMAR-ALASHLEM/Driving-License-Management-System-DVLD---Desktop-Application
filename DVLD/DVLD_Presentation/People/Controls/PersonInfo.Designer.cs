namespace DVLD_Presentation
{
    partial class PersonInfo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.gbPersonInformation = new System.Windows.Forms.GroupBox();
            this.lbEdit = new System.Windows.Forms.Label();
            this.lbCountry = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbDateOfBirth = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbGendor = new System.Windows.Forms.Label();
            this.lbNationalNo = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbPersonID = new System.Windows.Forms.Label();
            this.pbxPicturePerson = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gbPersonInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicturePerson)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPersonInformation
            // 
            this.gbPersonInformation.BackColor = System.Drawing.Color.White;
            this.gbPersonInformation.Controls.Add(this.label13);
            this.gbPersonInformation.Controls.Add(this.label7);
            this.gbPersonInformation.Controls.Add(this.label8);
            this.gbPersonInformation.Controls.Add(this.label9);
            this.gbPersonInformation.Controls.Add(this.label6);
            this.gbPersonInformation.Controls.Add(this.label5);
            this.gbPersonInformation.Controls.Add(this.label3);
            this.gbPersonInformation.Controls.Add(this.label2);
            this.gbPersonInformation.Controls.Add(this.lbEdit);
            this.gbPersonInformation.Controls.Add(this.pbxPicturePerson);
            this.gbPersonInformation.Controls.Add(this.lbCountry);
            this.gbPersonInformation.Controls.Add(this.lbPhone);
            this.gbPersonInformation.Controls.Add(this.lbDateOfBirth);
            this.gbPersonInformation.Controls.Add(this.lbAddress);
            this.gbPersonInformation.Controls.Add(this.lbEmail);
            this.gbPersonInformation.Controls.Add(this.lbGendor);
            this.gbPersonInformation.Controls.Add(this.lbNationalNo);
            this.gbPersonInformation.Controls.Add(this.lbName);
            this.gbPersonInformation.Controls.Add(this.lbPersonID);
            this.gbPersonInformation.Controls.Add(this.label4);
            this.gbPersonInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbPersonInformation.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.gbPersonInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbPersonInformation.Location = new System.Drawing.Point(4, 4);
            this.gbPersonInformation.Name = "gbPersonInformation";
            this.gbPersonInformation.Size = new System.Drawing.Size(1074, 372);
            this.gbPersonInformation.TabIndex = 1;
            this.gbPersonInformation.TabStop = false;
            this.gbPersonInformation.Text = "Person Details";
            this.gbPersonInformation.Enter += new System.EventHandler(this.gbPersonInformation_Enter_1);
            // 
            // lbEdit
            // 
            this.lbEdit.AutoSize = true;
            this.lbEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline);
            this.lbEdit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbEdit.Location = new System.Drawing.Point(863, 31);
            this.lbEdit.Name = "lbEdit";
            this.lbEdit.Size = new System.Drawing.Size(118, 21);
            this.lbEdit.TabIndex = 26;
            this.lbEdit.Text = "Edit Person Info";
            this.lbEdit.Click += new System.EventHandler(this.lbEdit_Click);
            // 
            // lbCountry
            // 
            this.lbCountry.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbCountry.ForeColor = System.Drawing.Color.Black;
            this.lbCountry.Location = new System.Drawing.Point(645, 230);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(155, 23);
            this.lbCountry.TabIndex = 25;
            this.lbCountry.Text = "[N/A]";
            // 
            // lbPhone
            // 
            this.lbPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbPhone.ForeColor = System.Drawing.Color.Black;
            this.lbPhone.Location = new System.Drawing.Point(645, 185);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(180, 23);
            this.lbPhone.TabIndex = 24;
            this.lbPhone.Text = "[N/A]";
            // 
            // lbDateOfBirth
            // 
            this.lbDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbDateOfBirth.ForeColor = System.Drawing.Color.Black;
            this.lbDateOfBirth.Location = new System.Drawing.Point(645, 138);
            this.lbDateOfBirth.Name = "lbDateOfBirth";
            this.lbDateOfBirth.Size = new System.Drawing.Size(180, 23);
            this.lbDateOfBirth.TabIndex = 23;
            this.lbDateOfBirth.Text = "[N/A]";
            // 
            // lbAddress
            // 
            this.lbAddress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbAddress.ForeColor = System.Drawing.Color.Black;
            this.lbAddress.Location = new System.Drawing.Point(229, 275);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(655, 61);
            this.lbAddress.TabIndex = 22;
            this.lbAddress.Text = "[N/A]";
            // 
            // lbEmail
            // 
            this.lbEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbEmail.ForeColor = System.Drawing.Color.Black;
            this.lbEmail.Location = new System.Drawing.Point(229, 230);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(200, 23);
            this.lbEmail.TabIndex = 21;
            this.lbEmail.Text = "[N/A]";
            // 
            // lbGendor
            // 
            this.lbGendor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbGendor.ForeColor = System.Drawing.Color.Black;
            this.lbGendor.Location = new System.Drawing.Point(229, 185);
            this.lbGendor.Name = "lbGendor";
            this.lbGendor.Size = new System.Drawing.Size(100, 23);
            this.lbGendor.TabIndex = 20;
            this.lbGendor.Text = "[N/A]";
            // 
            // lbNationalNo
            // 
            this.lbNationalNo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbNationalNo.ForeColor = System.Drawing.Color.Black;
            this.lbNationalNo.Location = new System.Drawing.Point(229, 140);
            this.lbNationalNo.Name = "lbNationalNo";
            this.lbNationalNo.Size = new System.Drawing.Size(200, 23);
            this.lbNationalNo.TabIndex = 19;
            this.lbNationalNo.Text = "[N/A]";
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbName.Location = new System.Drawing.Point(229, 83);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(450, 30);
            this.lbName.TabIndex = 18;
            this.lbName.Text = "[N/A]";
            // 
            // lbPersonID
            // 
            this.lbPersonID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbPersonID.ForeColor = System.Drawing.Color.Black;
            this.lbPersonID.Location = new System.Drawing.Point(229, 46);
            this.lbPersonID.Name = "lbPersonID";
            this.lbPersonID.Size = new System.Drawing.Size(100, 23);
            this.lbPersonID.TabIndex = 17;
            this.lbPersonID.Text = "N/A";
            // 
            // pbxPicturePerson
            // 
            this.pbxPicturePerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxPicturePerson.Image = global::DVLD_Presentation.Properties.Resources.Male_512;
            this.pbxPicturePerson.Location = new System.Drawing.Point(831, 75);
            this.pbxPicturePerson.Name = "pbxPicturePerson";
            this.pbxPicturePerson.Size = new System.Drawing.Size(190, 190);
            this.pbxPicturePerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxPicturePerson.TabIndex = 16;
            this.pbxPicturePerson.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::DVLD_Presentation.Properties.Resources.Person_32;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(15, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 25);
            this.label2.TabIndex = 40;
            this.label2.Text = " Name : ";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::DVLD_Presentation.Properties.Resources.Number_32;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(15, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 25);
            this.label3.TabIndex = 41;
            this.label3.Text = "National No : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(15, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gender : ";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = global::DVLD_Presentation.Properties.Resources.Email_32;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(15, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 25);
            this.label5.TabIndex = 43;
            this.label5.Text = "Email : ";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = global::DVLD_Presentation.Properties.Resources.Address_32;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(15, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 32);
            this.label6.TabIndex = 44;
            this.label6.Text = "Address :";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::DVLD_Presentation.Properties.Resources.Country_32;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(475, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 33);
            this.label9.TabIndex = 46;
            this.label9.Text = "Country :";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = global::DVLD_Presentation.Properties.Resources.Phone_32;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(493, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 25);
            this.label8.TabIndex = 47;
            this.label8.Text = "Phone :";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = global::DVLD_Presentation.Properties.Resources.Calendar_32;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(428, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 25);
            this.label7.TabIndex = 48;
            this.label7.Text = "Date Of Birth :";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Image = global::DVLD_Presentation.Properties.Resources.Number_32;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(15, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(199, 25);
            this.label13.TabIndex = 65;
            this.label13.Text = "Person ID :";
            // 
            // PersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbPersonInformation);
            this.Name = "PersonInfo";
            this.Size = new System.Drawing.Size(1087, 387);
            this.Load += new System.EventHandler(this.PersonInfo_Load);
            this.gbPersonInformation.ResumeLayout(false);
            this.gbPersonInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicturePerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        // الإبقاء على تعريف الكنترولات كما هي لضمان عدم حدوث أخطاء في الكود الخلفي
        private System.Windows.Forms.GroupBox gbPersonInformation;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbDateOfBirth;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbGendor;
        private System.Windows.Forms.Label lbNationalNo;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPersonID;
        private System.Windows.Forms.PictureBox pbxPicturePerson;
        private System.Windows.Forms.Label lbEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
    }
}