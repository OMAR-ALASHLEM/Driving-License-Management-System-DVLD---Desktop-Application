using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CountryName { get; set; }
        public string Address { get; set; }
        public string NationalNo { get; set; }
        public string ImagePath { get; set; }
        public byte Gendor { get; set; }
        public int NationalityCountryID { get; set; }
     
        public DateTime DateOfBirth { get; set; }
        public string FullName()
        { 

            return FirstName+" "+SecondName+" "+ThirdName+" "+LastName;
        }
        public clsPerson()
        {
            this.PersonID = 0;
            this.Gendor = 0;
           
            this.NationalityCountryID = 0;
            this.DateOfBirth = DateTime.Now;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.NationalNo = "";
            this.ImagePath = "";
            this.CountryName = "";
            Mode = enMode.AddNew;

        }

        private clsPerson(int PersonID, string NationalNO, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
          byte Gendor, string Address, string Phone, string Email, int NationalCountryID, string ImagePath,string CountryName)
                        {
            this.PersonID = PersonID;
            this.Gendor = Gendor;
            this.NationalityCountryID = NationalCountryID;
            this.DateOfBirth = DateOfBirth;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.NationalNo = NationalNO;
            this.ImagePath = ImagePath;
            this.CountryName = CountryName;
            Mode = enMode.Update;
        }
        public static clsPerson Find(int PersonID)
        {
            int  NationalCountryID = -1;
            byte Gendor = 0;
            string NationalNO = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "",CountryName="";
            DateTime DateOfBirth = DateTime.Now;
            if (clsPersonData.GetPersonByID(PersonID, ref NationalNO, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID,  NationalNO,  FirstName,  SecondName,  ThirdName,  LastName,  DateOfBirth,  Gendor,  Address,  Phone,  Email,  NationalCountryID,ImagePath, clsCountriesData.GetCountryName(NationalCountryID, CountryName));

            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static bool IsExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(
                this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.NationalNo, this.DateOfBirth, this.Gendor, this.Address,
                this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(
                this.PersonID, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.NationalNo, this.DateOfBirth, this.Gendor,
                this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();

                default:
                    return false;
            }
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

    }
}
