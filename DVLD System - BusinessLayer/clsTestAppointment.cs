using DVLD_System___DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___BusinessLayer
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        public clsTestAppointment() 
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;

            Mode = enMode.AddNew;
        }

        private clsTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees= PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;

            Mode = enMode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateTestAppointment();
                    }
            }

            return false;
        }        

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1;
            decimal PaidFees = 0;
            bool IsLocked = false;
            DateTime AppointmentDate = DateTime.Now;

            if (clsTestAppointmentData.GetTestAppointmentInfoByTestAppointmentID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked))
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);
            else
                return null;
        }

        public static DataTable GetAllTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentData.GetAllTestAppointment(LocalDrivingLicenseApplicationID, TestTypeID);
        }
    }
}
