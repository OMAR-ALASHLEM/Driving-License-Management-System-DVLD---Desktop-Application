using DVLD_Business;
using DVLD_Presentation.Applications.Local_Driving_License;
using DVLD_Presentation.People;
using DVLD_Presentation.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmListLocalDrivingLicesnseApplications());
            bool keepRunning = true;

            while (keepRunning)
            {

                using (frmLogin loginForm = new frmLogin())
                {

                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {

                        Application.Run(new MainForm());


                        if (clsGlobal.CurrentUser == null)
                        {
                            keepRunning = true;
                        }
                        else
                        {
                            keepRunning = false;
                        }
                    }
                    else
                    {

                        keepRunning = false;
                    }
                }
            }
        }
    }
}
