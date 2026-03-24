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
        public string SecondtName { get; set; }
        public string ThirdName { get; set; }
        public string LasttName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CountryName { get; set; }
        public string Address { get; set; }
        public string NationalNo { get; set; }
        public string ImagePath { get; set; }
        public byte Gendor { get; set; }
        public int NationalCountryID { get; set; }
     
        public DateTime DateOfBirth { get; set; }
        public string FullName()
        { 

            return FirstName+" "+SecondtName+" "+ThirdName+" "+LasttName;
        }
        public clsPerson()
        {
            this.PersonID = 0;
            this.Gendor = 0;
           
            this.NationalCountryID = 0;
            this.DateOfBirth = DateTime.Now;
            this.FirstName = "";
            this.SecondtName = "";
            this.ThirdName = "";
            this.LasttName = "";
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
            this.NationalCountryID = NationalCountryID;
            this.DateOfBirth = DateOfBirth;
            this.FirstName = FirstName;
            this.SecondtName = SecondName;
            this.ThirdName = ThirdName;
            this.LasttName = LastName;
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
                return new clsPerson(PersonID,  NationalNO,  FirstName,  SecondName,  ThirdName,  LastName,  DateOfBirth,  Gendor,  Address,  Phone,  Email,  NationalCountryID,ImagePath,  clsCountriesData.GetCountryName(NationalCountryID,ref CountryName));

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



    }
}
