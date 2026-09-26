using DVLD_System___DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___BusinessLayer
{
    public class clsTest
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest() 
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1; 
        }

        private clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return (this.TestID != -1);
        }

        public bool Save()
        {
            return _AddNewTest();
        }

        public static bool IsPersonPassed(int LocalDrivingLicenseApplicationID, int TestType)
        {
            return clsTestData.IsPersonPassed(LocalDrivingLicenseApplicationID, TestType);
        }
    }
}
