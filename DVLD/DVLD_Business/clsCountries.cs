using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsCountries
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public clsCountries()
        {
            
        }
        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountries();  
        }
        public static string GetCountryName(int ID, string CountryName="") 
        {

            return clsCountriesData.GetCountryName(ID, CountryName);
        
        }
        public static int GetCountryIDByName(string CountryName)
        {
            int ID = 0;
            clsCountriesData.GetCountryInfoByName(CountryName,ref ID);
            return ID;
        }
    }
}
