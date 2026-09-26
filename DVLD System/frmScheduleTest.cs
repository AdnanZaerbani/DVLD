using DVLD_System.Properties;
using DVLD_System___BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class frmScheduleTest : Form
    {
        public frmScheduleTest()
        {
            InitializeComponent();
        }

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _Trail;
        int _DLAppID;
        int _AppID;
        int _TestAppID;
        int _TestNum;
        clsApplication _App;
        clsApplicationType _AppType;
        clsLocalDrivingLicenseApplication _DLApp;
        clsTestType _TestType;
        clsTestAppointment _TestAppointment;
        public frmScheduleTest(int DLAppID, int AppID, int Trail, int TestNum, int TestAppID = -1)
        {
            InitializeComponent();
            _TestNum = TestNum;
            if (TestNum == 1)
            {
                gbTitle.Text = "Vision Test";
                pbTitle.Image = Resources.Vision_512;
            }
            if (TestNum == 2)
            {
                gbTitle.Text = "Written Test";
                pbTitle.Image = Resources.Written_Test_512;
            }
            if (TestNum == 3)
            {
                gbTitle.Text = "Street Test";
                pbTitle.Image = Resources.driving_test_512;
            }
            _DLAppID = DLAppID;
            _AppID = AppID;
            _TestAppID = TestAppID;
            _Trail = Trail - 1;
            if (_Trail != 0)
            {
                gbRetakeTestInfo.Enabled = true;

            }
            if (_TestAppID == -1)
                _Mode = enMode.AddNew;
            else
            {
                gbRetakeTestInfo.Enabled = false;
                _Mode = enMode.Update;
            }
        }

        private void _LoadData()
        {
            _DLApp = clsLocalDrivingLicenseApplication.Find(_DLAppID);
            _App = clsApplication.Find(_AppID);
            _TestType = clsTestType.Find(_TestNum);
            _AppType = clsApplicationType.Find(7);
            lblDLAppID.Text = _DLAppID.ToString();
            lblDClass.Text = _DLApp.ClassName;
            lblName.Text = _App.FullName;
            lblFees.Text = _TestType.TestTypeFees.ToString("00");
            lblTrial.Text = _Trail.ToString();
            dtpDate.Value = DateTime.Now;
            if (gbRetakeTestInfo.Enabled == true)
            {
                lblRAppFees.Text = _AppType.ApplicationFees.ToString("0");
            }
            else
            {
                lblRAppFees.Text = "0";
            }

            lblTotalFees.Text = (Convert.ToInt32(lblRAppFees.Text) + _TestType.TestTypeFees).ToString("00");

            if (_Mode == enMode.AddNew)
            {
                _TestAppointment = new clsTestAppointment();

                _TestAppointment.AppointmentDate = dtpDate.Value;
                
                
                return;
            }

            
            _TestAppointment = clsTestAppointment.Find(_TestAppID);

            if (_TestAppointment == null)
            {
                MessageBox.Show(
                    "Test Appointment not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            dtpDate.Value = _TestAppointment.AppointmentDate;

            lblRAppFees.Text = "0";

            lblTotalFees.Text = _TestAppointment.PaidFees.ToString("0");
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestAppointment.TestTypeID = _TestType.TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _DLAppID;
            _TestAppointment.AppointmentDate = dtpDate.Value;
            _TestAppointment.PaidFees = _TestType.TestTypeFees;
            _TestAppointment.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
            _TestAppointment.IsLocked = false;

            if (_TestAppointment.Save())
            {
                lblRTestAppID.Text = _TestAppointment.TestAppointmentID.ToString();
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Error : Data was not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
