using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplication
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        private clsApplicationType _ApplicationTypeInfo;
        public clsApplicationType ApplicationTypeInfo
        {

            get
            {
                if (_ApplicationTypeInfo == null && this.ApplicationTypeID != -1)
                    _ApplicationTypeInfo = clsApplicationType.GetApplicationTypeByID(ApplicationTypeID);

                return _ApplicationTypeInfo;
            }
            set { _ApplicationTypeInfo = value; }
        }
        private clsUser _CreatedByUserInfo;
        public clsUser CreatedByUserInfo
        {
            get
            {
                if (_CreatedByUserInfo == null && this.CreatedByUserID != -1)
                    _CreatedByUserInfo = clsUser.Find(CreatedByUserID);

                return _CreatedByUserInfo;
            }
            set { _CreatedByUserInfo = value; }
        }
        private clsPerson _PersonInfo;
        public clsPerson PersonInfo
        {
            get
            {
                if (_PersonInfo == null && this.ApplicantPersonID != -1)
                    _PersonInfo = clsPerson.Find(ApplicantPersonID);

                return _PersonInfo;
            }
            set { _PersonInfo = value; }
        }

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public string StatusText
        {
            get
            {

                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }

        }
        public string ApplicantFullName => this.PersonInfo?.FullName();
        private clsApplication(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            Mode = enMode.Update;
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = (enApplicationStatus)applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
        }
        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }
        public static clsApplication Find(int ApplicationID)
        {

            int ApplicantPersonID = -1;
            DateTime applicationDate = DateTime.MinValue, lastStatusDate = DateTime.MinValue;
            int applicationTypeID = -1, createdByUserID = -1;
            float paidFees = -1;
            byte applicationStatus = 0;

            if (clsApplicationData.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID, ref applicationDate, ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, applicationDate, applicationTypeID, applicationStatus, lastStatusDate, paidFees, createdByUserID);
            }
            return null;
        }
        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, (byte)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            return (this.ApplicationID != -1);
        }
        private bool _UpdateApplication() => clsApplicationData.UpdateApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, (byte)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateApplication();
            }
            return false;
        }
        public bool Cancel() =>  clsApplication.Cancel(this.ApplicationID);
        public static bool Cancel(int ApplicationID) => clsApplicationData.UpdateStatus(ApplicationID, 2);
        public bool SetComplete() => clsApplication.SetComplete(this.ApplicationID);
        public static bool SetComplete(int ApplicationID) => clsApplicationData.UpdateStatus(ApplicationID, 3);
        public bool Delete() => clsApplication.Delete(this.ApplicationID);
        public static bool Delete(int ApplicationID) => clsApplicationData.DeleteApplication(ApplicationID);
        public static bool IsApplicationExist(int ApplicationID) => clsApplicationData.IsApplicationExist(ApplicationID);
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID) => clsApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID) => DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        public static int GetActiveApplicationID(int PersonID, clsApplication.enApplicationType ApplicationTypeID) => clsApplicationData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID) => clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        public int GetActiveApplicationID(clsApplication.enApplicationType ApplicationTypeID) => GetActiveApplicationID(this.ApplicantPersonID, ApplicationTypeID);

    }
}
