using DVLD_System___DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___BusinessLayer
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        public clsLicenseClass() 
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.DefaultValidityLength = 0;
            this.ClassFees = 0;
        }

        private clsLicenseClass(string ClassName, int LicenseClassID)
        {
            this.ClassName = ClassName;
            this.LicenseClassID = LicenseClassID;
        }

        private clsLicenseClass(int LicenseClassID, string ClassName, byte DefaultValidityLength, decimal ClassFees)
        {
            this.ClassName = ClassName;
            this.LicenseClassID = LicenseClassID;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        public static clsLicenseClass Find(string ClassName)
        {
            int LicenseClassID = -1;
            if (clsLicenseClassData.GetLicenseClassIDByClassName(ClassName, ref LicenseClassID))
                return new clsLicenseClass(ClassName, LicenseClassID);
            else
                return null;
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = "";
            decimal ClassFees = 0;
            byte DefaultValidityLength = 0;
            if (clsLicenseClassData.GetLicenseClassInofByLicenseClassID(LicenseClassID, ref ClassName, ref DefaultValidityLength, ref ClassFees))
                return new clsLicenseClass(LicenseClassID, ClassName, DefaultValidityLength, ClassFees);
            else
                return null;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }
    }
}
