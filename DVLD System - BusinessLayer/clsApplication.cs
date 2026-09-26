using DVLD_System___DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___BusinessLayer
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public string AppTitle {  get; set; }
        public decimal AppFees { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }

        public clsApplication() 
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 0;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
        }

        private clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees= PaidFees;
            this.CreatedByUserID = CreatedByUserID;
        }

        private clsApplication(int ApplicationID, int ApplicantPersonID, byte ApplicationStatus, string AppTitle, decimal AppFees, DateTime ApplicationDate, DateTime LastStatusDate, string UserName, string FullName)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID= ApplicantPersonID;
            this.ApplicationStatus = ApplicationStatus;
            this.AppTitle = AppTitle;
            this.AppFees = AppFees;
            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = LastStatusDate;
            this.UserName = UserName;
            this.FullName = FullName;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }

        public bool UpdateApplicationStatus(int ApplicationID, byte ApplicationStatus)
        {
            return clsApplicationData.UpdateApplicationStatus(ApplicationID, ApplicationStatus);
        }

        public bool Save()
        {
            return _AddNewApplication();
        }

        public static clsApplication Find(int AppID)
        {
            string AppTypeTitle = "", UserName = "", FullName = "";
            byte AppStatus = 0;
            DateTime AppDate = DateTime.Now , LastStatusDate = DateTime.Now ;
            decimal AppFees = 0;
            int ApplicantPersonID = -1;
            if (clsApplicationData.GetApplicationInfoByAppID(AppID, ref ApplicantPersonID, ref AppStatus, ref AppTypeTitle, ref AppFees, ref AppDate, ref LastStatusDate, ref UserName, ref FullName))
                return new clsApplication(AppID, ApplicantPersonID, AppStatus, AppTypeTitle, AppFees, AppDate, LastStatusDate, UserName, FullName);
            else
                return null;
        }
    }
}
