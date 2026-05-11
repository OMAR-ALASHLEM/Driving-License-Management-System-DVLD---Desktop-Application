namespace DVLD_Presentation
{
    partial class frmtest
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
            this.crlScheduleTest1 = new DVLD_Presentation.Tests.Controls.crlScheduleTest();
            this.SuspendLayout();
            // 
            // crlScheduleTest1
            // 
            this.crlScheduleTest1.BackColor = System.Drawing.Color.White;
            this.crlScheduleTest1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crlScheduleTest1.Location = new System.Drawing.Point(12, 12);
            this.crlScheduleTest1.Name = "crlScheduleTest1";
            this.crlScheduleTest1.Size = new System.Drawing.Size(818, 891);
            this.crlScheduleTest1.TabIndex = 0;
            this.crlScheduleTest1.TestTypeID = DVLD_Business.clsTestTypes.enTestType.VisionTest;
            // 
            // frmtest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 1058);
            this.Controls.Add(this.crlScheduleTest1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmtest";
            this.Text = "frmtest";
            this.Load += new System.EventHandler(this.frmtest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tests.Controls.crlScheduleTest crlScheduleTest1;
    }
}