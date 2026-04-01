using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int ID { set; get; }
        public string Title { set; get; }
        public float Fees { set; get; }

        public clsApplicationType()

        {
            this.ID = -1;
            this.Title = "";
            this.Fees = 0;
            Mode = enMode.AddNew;

        }

        public clsApplicationType(int ID, string ApplicationTypeTitel, float ApplicationTypeFees)

        {
            this.ID = ID;
            this.Title = ApplicationTypeTitel;
            this.Fees = ApplicationTypeFees;
            Mode = enMode.Update;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();

        }
        private bool _Update()
        {
            return clsApplicationTypesData.UpdateApplicationType(this.ID, this.Title, this.Fees);
        }

        public bool Save()
        {

            if (Mode==enMode.Update)
            {
                return  _Update();
            }
            else
            {
                return false; 
            }
        }

        public clsApplicationType GetApplicationTypeByID(int ApplicationTypeID)
        {
            string Title="";float Fees=0;
            if (clsApplicationTypesData.GetApplicationTypeInfoByID(ApplicationTypeID, ref Title, ref Fees))
            {
               return new clsApplicationType(ApplicationTypeID, Title, Fees);
            }
            return null;
        }
    }
}
