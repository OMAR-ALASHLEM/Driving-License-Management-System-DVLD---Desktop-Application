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

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public clsTestTypes.enTestType ID { set; get; }
     
        public string TestTypeTitle { set; get; }
        public string TestTypeDescription { set; get; }
        public float TestTypeFees { set; get; }

        public clsTestTypes()
        {
            this.ID = clsTestTypes.enTestType.VisionTest;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
            Mode = enMode.AddNew;
        }

        private clsTestTypes(clsTestTypes.enTestType ID, string Title, string Description, float Fees)
        {
            this.ID = ID;
            this.TestTypeTitle = Title;
            this.TestTypeDescription = Description;
            this.TestTypeFees = Fees;
            Mode = enMode.Update;
        }

        public static clsTestTypes Find(clsTestTypes.enTestType TestTypeID)
        {
            string Title = "", Description = ""; float Fees = 0;
            if (clsTestTypesData.GetTestTypeInfoByID((int)TestTypeID, ref Title, ref Description, ref Fees))
            {
                return new clsTestTypes(TestTypeID, Title, Description, Fees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllTetTypes() => clsTestTypesData.GetAllTestTypes();

        private bool _AddNewTestType()
        {
            
            this.ID = (clsTestTypes.enTestType)clsTestTypesData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            return (this.TestTypeTitle != "");
        }
        private bool _Update() => clsTestTypesData.UpdateTestType((int)this.ID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

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
