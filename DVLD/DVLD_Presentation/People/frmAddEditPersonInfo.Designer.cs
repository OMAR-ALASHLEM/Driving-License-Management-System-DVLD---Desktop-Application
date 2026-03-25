namespace DVLD_Presentation.People
{
    partial class frmAddEditPersonInfo
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
            this.addEditPersonInfo1 = new DVLD_Presentation.People.AddEditPersonInfo();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addEditPersonInfo1
            // 
            this.addEditPersonInfo1.Location = new System.Drawing.Point(10, 8);
            this.addEditPersonInfo1.Name = "addEditPersonInfo1";
            this.addEditPersonInfo1.Size = new System.Drawing.Size(1077, 637);
            this.addEditPersonInfo1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.button1.Image = global::DVLD_Presentation.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(598, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 47);
            this.button1.TabIndex = 38;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAddEditPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 659);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addEditPersonInfo1);
            this.Name = "frmAddEditPersonInfo";
            this.Text = "Add / Edit Person Info";
            this.Load += new System.EventHandler(this.frmAddEditPersonInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AddEditPersonInfo addEditPersonInfo1;
        private System.Windows.Forms.Button button1;
    }
}