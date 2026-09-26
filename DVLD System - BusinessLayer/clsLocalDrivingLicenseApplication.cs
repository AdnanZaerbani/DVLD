using DVLD_System___DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___BusinessLayer
{
    public class clsLocalDrivingLicenseApplication
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public int LDLAppID { get; set; }

        public string ClassName { get; set; }

        public int PassedTestCount { get; set; }

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;

            Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;

            Mode = enMode.Update;
        }

        private clsLocalDrivingLicenseApplication(int LDLAppID, string ClassName, int PassedTestCount)
        {
            this.LDLAppID = LDLAppID;
            this.ClassName = ClassName;
            this.PassedTestCount = PassedTestCount;

            Mode = enMode.Update;
        }

      
        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }

       

        public bool Save()
        {
            

            return _AddNewLocalDrivingLicenseApplication();
        }

        public static bool DeleteApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.DeleteLDLApplication(LocalDrivingLicenseApplicationID);
        }

        public static DataTable GetAllLDLA()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLDLA();
        }

        public static clsLocalDrivingLicenseApplication Find(int LDLAppID)
        {
            string ClassName = "";
            int PassedTestCount = 0;

            if (clsLocalDrivingLicenseApplicationData.GetDLAppByID(LDLAppID, ref ClassName, ref PassedTestCount))
                return new clsLocalDrivingLicenseApplication(LDLAppID, ClassName, PassedTestCount);
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseApplicationID, string koko = "")
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationData.GetDLAppByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
            else
                return null;
        }

        public static bool IsPersonHasActiveApplication(int PersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData.IsPersonHasActiveApplication(PersonID, LicenseClassID);
        }
    }
}
