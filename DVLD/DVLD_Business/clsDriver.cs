using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDriver
    {
        private clsPerson _Person;
        private int _Person_ID;
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int DriverID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Person_ID
        {
            get { return _Person_ID; }
            set
            {
                _Person_ID = value;
                this.PersonInfo = clsPerson.Find(value);
            }
        }
        public clsPerson PersonInfo
        {
            get
            {
                if (_Person == null && this.Person_ID != -1)
                    _Person = clsPerson.Find(this.Person_ID);

                return _Person;
            }
            set { _Person = value; }
        }
        public clsDriver()
        {
            DriverID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            Person_ID = -1;
        }
        private clsDriver(int driverID, int createdByUserID, DateTime createdDate, int person_ID)
        {
            DriverID = driverID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            Person_ID = person_ID;
        }
        public static clsDriver FindByPersonID(int personID)
        {
            int createdByUserID = -1; DateTime createdDate = DateTime.MinValue; int DriverID = -1;
            if (clsDriversData.GetDriverInfoByPersonID(personID, ref DriverID, ref createdByUserID, ref createdDate))
                return new clsDriver(DriverID, createdByUserID, createdDate, personID);
            else
                return null;
        }
        public static clsDriver FindByDriverID(int DriverID)
        {
            int createdByUserID = -1; DateTime createdDate = DateTime.MinValue; int person_ID = -1;
            if (clsDriversData.GetDriverInfoByDriverID(DriverID, ref person_ID, ref createdByUserID, ref createdDate))
                return new clsDriver(DriverID, createdByUserID, createdDate, person_ID);
            else
                return null;
        }
        private bool _UpdateDriver() => clsDriversData.UpdateDriver(this.DriverID, this.Person_ID, this.CreatedByUserID);
        private bool _AddNewDriver()
        {
            int newID = clsDriversData.AddNewDriver(this.Person_ID, this.CreatedByUserID);
            if (newID != -1)
            {
                this.DriverID = newID;
                Mode = enMode.Update;
                return true;
            }
            return false;
        }
        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if (_AddNewDriver())
                {
                    Mode = enMode.Update;
                    return true;
                }
                return false;
            }
            else
            {
                return _UpdateDriver();
            }

        }
        public static DataTable GetAllDrivers() => clsDriversData.GetAllDrivers();
        public static DataTable GetLicenses(int DriverID) => clsLicenses.GetDriverLicenses(DriverID);


    }
}
