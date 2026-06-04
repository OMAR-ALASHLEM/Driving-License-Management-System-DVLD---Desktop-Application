using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsInternationalDrivingLicenseApplicaiton : clsApplication
    {
        public new enum enMode { AddNew = 0, Update = 1 };
        public new enMode Mode = enMode.AddNew;

        private int _InternationalLicenseID;
        private int _ApplicationID;
        private int _DriverID;
        private int _IssuedUsingLocalLicenseID;
        private DateTime _IssueDate;
        private DateTime _ExpirationDate;
        private bool _IsActive;
        private int _CreatedByUserID;
        private clsDriver _Driver;
        private int _Person_ID;
        public int Driver_ID
        {
            get { return _Person_ID; }
            set
            {
                _Person_ID = value;
                this.Driver = clsDriver.FindByDriverID(value);
            }
        }
        public clsDriver Driver
        {
            get
            {
                if (_Driver == null && this.Driver_ID != -1)
                    _Driver = clsDriver.FindByDriverID(this.Driver_ID);

                return _Driver;
            }
            set { _Driver = value; }
        }
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public new int CreatedByUserID { get; set; }
        private clsInternationalDrivingLicenseApplicaiton(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID,
             int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;

            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this._DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
        }
        public clsInternationalDrivingLicenseApplicaiton()

        {
            this.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            this.InternationalLicenseID = -1;
            this._DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = true;
            Mode = enMode.AddNew;

        }

        private bool _AddNewInternationalLicense()
        {

            this.InternationalLicenseID =
                clsInternationalDrivingLicenseApplicaitonData.AddNewInternationalDrivingLicenseApplicaiton(this.ApplicationID, this._DriverID, this.IssuedUsingLocalLicenseID,
               this.IssueDate, this.ExpirationDate,
               this.IsActive, this.CreatedByUserID);


            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense() => clsInternationalDrivingLicenseApplicaitonData.UpdateLocalDrivingLicenseApplication(
                this.InternationalLicenseID, this.ApplicationID, this._DriverID, this.IssuedUsingLocalLicenseID,
               this.IssueDate, this.ExpirationDate,
               this.IsActive, this.CreatedByUserID);

        public static clsInternationalDrivingLicenseApplicaiton Find(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1; int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            bool IsActive = true; int CreatedByUserID = 1;

            if (clsInternationalDrivingLicenseApplicaitonData.GetInternationalDrivingLicenseApplicaitonInfoByID(InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID,
            ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
             
                clsApplication Application = clsApplication.Find(ApplicationID);


                return new clsInternationalDrivingLicenseApplicaiton(Application.ApplicationID,
                    Application.ApplicantPersonID,
                                     Application.ApplicationDate,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID,
                                     InternationalLicenseID, DriverID, IssuedUsingLocalLicenseID,
                                         IssueDate, ExpirationDate, IsActive);

            }

            else
                return null;

        }

        public static DataTable GetAllInternationalLicenses() => clsInternationalDrivingLicenseApplicaitonData.GetAllInternationalDrivingLicenseApplicaiton();

        public bool Save()
        {

          
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateInternationalLicense();

            }

            return false;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID) => clsInternationalDrivingLicenseApplicaitonData.GetActiveInternationalLicenseIDByDriverID(DriverID);

        public static DataTable GetDriverInternationalLicenses(int DriverID) => clsInternationalDrivingLicenseApplicaitonData.GetDriverInternationalLicenses(DriverID);

    }
}
