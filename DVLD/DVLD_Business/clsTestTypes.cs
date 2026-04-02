using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Business
{
    public class clsTestTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int TestTypeID { set; get; }
        public string TestTypeTitle { set; get; }
        public string TestTypeDescription { set; get; }
        public float TestTypeFees { set; get; }

        public clsTestTypes()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
            Mode = enMode.AddNew;
        }

        private clsTestTypes(int TestTypeID, string Title, string Description, float Fees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = Title;
            this.TestTypeDescription = Description;
            this.TestTypeFees = Fees;
            Mode = enMode.Update;
        }

        public static clsTestTypes Find(int TestTypeID)
        {
            string Title = "", Description = ""; float Fees = 0;
            if (clsTestTypesData.GetTestTypeInfoByID(TestTypeID, ref Title, ref Description, ref Fees))
            {
                return new clsTestTypes(TestTypeID, Title, Description, Fees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllTetTypes() => clsTestTypesData.GetAllTestTypes();

        private bool _Update() => clsTestTypesData.UpdateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

        public bool Save()
        {
            if(Mode== enMode.Update)
            {
                return _Update();   
            }
            else
            {
                return false;   
            }


        }

    }
}
