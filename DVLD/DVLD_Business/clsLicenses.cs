using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicenses
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };


        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public int CreatedByUserID { get; set; }
        public enIssueReason IssueReason { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime IssueDate { get; set; }
        public bool IsActive { get; set; }
        public float PaidFees { get; set; }
        public string Notes { get; set; }

        private clsLicenseClass _LicenseClassInfo;

        public clsLicenseClass LicenseClassInfo
        {
            get
            {
                if (_LicenseClassInfo == null)
                {
                    _LicenseClassInfo = clsLicenseClass.Find(this.LicenseClass);
                }
                return _LicenseClassInfo;
            }
        }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }

        public clsLicenses()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.CreatedByUserID = -1;
            this.IssueReason = 0;
            this.PaidFees = -1;
            this.ExpirationDate = DateTime.Now;
            this.IssueDate = DateTime.Now;
            this.IsActive = false;
            this.IssueReason = enIssueReason.FirstTime;

            this.Notes = "";
        }

        private clsLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
        DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.CreatedByUserID = CreatedByUserID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.PaidFees = PaidFees;
            this.IssueReason = IssueReason;
            Mode = enMode.Update;
        }

        public static clsLicenses Find(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = -1;
            bool IsActive = false;
            byte IssueReason = 0;
            if (clsLicensesData.GetLicenseClassInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
        ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive,(enIssueReason) IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }
        public static DataTable GetAllLicenses()=> clsLicensesData.GetAllLicenses();
        public static bool DeactivateLicense(int LicenseID) => clsLicensesData.DeactivateLicense(LicenseID);
        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID) => (clsLicensesData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID) => clsLicensesData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        private bool _AddNewLicense()
        {
          

            this.LicenseID = clsLicensesData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);


            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()=>clsLicensesData.UpdateLicense(this.ApplicationID, this.LicenseID, this.DriverID, this.LicenseClass,  this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
        this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }

            return false;
        }

        public Boolean IsLicenseExpired()
        {

            return (this.ExpirationDate < DateTime.Now);

        }

        public static DataTable GetDriverLicenses(int DriverID)=> clsLicensesData.GetDriverLicenses(DriverID);
       
    }
}
