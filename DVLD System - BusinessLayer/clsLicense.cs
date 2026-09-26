using DVLD_System___DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___BusinessLayer
{
    public class clsLicense
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public string FullName { get; set; }
        public string ClassName { get; set; }
        public string NationalNo { get; set; }
        public byte Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }


        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.LicenseClass = -1;
            this.DriverID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;
            this.FullName = "";
            this.ClassName = "";
            this.NationalNo = "";
            this.Gender = 0;
            this.DateOfBirth = DateTime.Now;
            this.ImagePath = "";
        }

        private clsLicense(int ApplicationID, int LicenseID, string ClassName, string FullName, string NationalNo, byte Gender ,DateTime IssueDate, byte IssueReason, string Notes, bool IsActive, DateTime DateOfBirth, int DriverID, DateTime ExpirationDate, string ImagePath)
        {
            this.ApplicationID = ApplicationID;
            this.LicenseID = LicenseID;
            this.ClassName = ClassName;
            this.FullName = FullName;
            this.NationalNo = NationalNo;
            this.Gender = Gender;
            this.IssueDate = IssueDate;
            this.IssueReason = IssueReason;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.DateOfBirth = DateOfBirth;
            this.DriverID = DriverID;
            this.ExpirationDate = ExpirationDate;
            this.ImagePath = ImagePath;
        }

        private clsLicense(int LicenseID, string ClassName, string FullName, string NationalNo, byte Gender, DateTime IssueDate, byte IssueReason, string Notes, bool IsActive, DateTime DateOfBirth, int DriverID, DateTime ExpirationDate, string ImagePath)
        {
            this.LicenseID = LicenseID;
            this.ClassName = ClassName;
            this.FullName = FullName;
            this.NationalNo = NationalNo;
            this.Gender = Gender;
            this.IssueDate = IssueDate;
            this.IssueReason = IssueReason;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.DateOfBirth = DateOfBirth;
            this.DriverID = DriverID;
            this.ExpirationDate = ExpirationDate;
            this.ImagePath = ImagePath;
        }

        private clsLicense(int LicenseID, int ApplicationID)
        {
            this.LicenseID= LicenseID;
            this.ApplicationID= ApplicationID;
        }
        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
            return (this.LicenseID != -1);
        }

        public bool UpdateLicenseActive()
        {
            return clsLicenseData.UpdateLicenseActive(this.LicenseID, this.IsActive);
        }

        public bool Save()
        {
            return _AddNewLicense();
        }

        public static clsLicense Find(int ApplicationID)
        {
            string ClassName = "", FullName = "", ImagePath = "", NationalNo = "", Notes = "";
            int DriverID = -1, LicenseID = -1;
            byte IssueReason = 0;
            byte Gender = 0;
            bool IsActive = false;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now, DateOfBirth = DateTime.Now;
            if (clsLicenseData.GetLicenseInfoByApplicationID(ApplicationID, ref LicenseID, ref ClassName, ref FullName, ref NationalNo, ref Gender, ref IssueDate, ref IssueReason, ref Notes, ref IsActive, ref DateOfBirth, ref DriverID, ref ExpirationDate, ref ImagePath))
                return new clsLicense(ApplicationID, LicenseID, ClassName, FullName, NationalNo, Gender, IssueDate, IssueReason, Notes, IsActive, DateOfBirth, DriverID, ExpirationDate, ImagePath);
            else
                return null;
        }

        public static clsLicense FindLicense(int LicenseID)
        {
            string ClassName = "", FullName = "", ImagePath = "", NationalNo = "", Notes = "";
            int DriverID = -1;
            byte IssueReason = 0;
            byte Gender = 0;
            bool IsActive = false;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now, DateOfBirth = DateTime.Now;
            if (clsLicenseData.GetLicenseInfoByLicenseID(LicenseID, ref ClassName, ref FullName, ref NationalNo, ref Gender, ref IssueDate, ref IssueReason, ref Notes, ref IsActive, ref DateOfBirth, ref DriverID, ref ExpirationDate, ref ImagePath))
                return new clsLicense(LicenseID, ClassName, FullName, NationalNo, Gender, IssueDate, IssueReason, Notes, IsActive, DateOfBirth, DriverID, ExpirationDate, ImagePath);
            else
                return null;
        }

        public static clsLicense FindLicenseApplication(int LicenseID)
        {
            int Application = -1;
            if (clsLicenseData.GetApplicationIDByLicenseID(LicenseID, ref Application))
                return new clsLicense(LicenseID, Application);
            else
                return null;
        }
        public static DataTable GetAllLicense(int PersonID)
        {
            return clsLicenseData.GetAllLicense(PersonID);
        }

        public static bool IsPersonHasLicense(int LicenseClass, int PersonID)
        {
            return clsLicenseData.IsPersonHasLicense(LicenseClass, PersonID);
        }
    }
}
