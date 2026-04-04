using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicenseClass
    {


        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = -1;

        }

        private clsLicenseClass(int LicenseClassID, string ClassName,
            string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }


        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = "";
            string ClassDescription = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            float ClassFees = 0;
            if (clsLicenseClassData.GetLicenseClassInfoByID(LicenseClassID, ref ClassName, ref ClassDescription,
                ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge,
                    DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllLicenseClasses() => clsLicenseClassData.GetAllLicenseClasses();
     
    }
}
