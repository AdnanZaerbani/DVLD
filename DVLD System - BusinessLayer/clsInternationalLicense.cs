using DVLD_System___DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___BusinessLayer
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = false;
            this.CreatedByUserID = -1;
        }

        public clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID =CreatedByUserID;
        }

        public clsInternationalLicense(int IssuedUsingLocalLicenseID, int InternationalLicenseID, int ApplicationID, int DriverID , DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID, string koko = "")
        {
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
            return (this.InternationalLicenseID != -1);
        }

        public bool Save()
        {
            return _AddNewInternationalLicense();
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            if (clsInternationalLicenseData.GetIntLicenseByID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            else
                return null;
        }

        public static clsInternationalLicense FindIntLicense(int  IssuedUsingLocalLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, InternationalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            if (clsInternationalLicenseData.GetIntLicenseByLicenseID(IssuedUsingLocalLicenseID , ref InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
                return new clsInternationalLicense(IssuedUsingLocalLicenseID , InternationalLicenseID, ApplicationID, DriverID, IssueDate, ExpirationDate, IsActive, CreatedByUserID , "");
            else
                return null;
        }

        public static DataTable GetInternationalLicense(int PersonID)
        {
            return clsInternationalLicenseData.GetInternationalLicense(PersonID);
        }

        public static DataTable GetAllInternationalLicense()
        {
            return clsInternationalLicenseData.GetAllInternationalLicense();
        }

        public static bool IsPersonHasIntLicenseID(int IssuedUsingLocalLicenseID)
        {
            return clsInternationalLicenseData.IsPersonHasIntLicense(IssuedUsingLocalLicenseID);
        }
    }
}
