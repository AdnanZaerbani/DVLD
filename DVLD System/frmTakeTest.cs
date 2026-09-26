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
    public partial class frmTakeTest : Form
    {
        public frmTakeTest()
        {
            InitializeComponent();
        }
        int _Trial;
        int _DLAppID;
        int _AppID;
        int _TestAppID;
        clsApplication _App;
        clsApplicationType _AppType;
        clsLocalDrivingLicenseApplication _DLApp;
        clsTestType _TestType;
        clsTestAppointment _TestAppointment;
        clsTest _Test = new clsTest();
        public frmTakeTest(int DLAppID, int AppID, int TestAppID, int Trial)
        {
            InitializeComponent();
            _DLAppID = DLAppID;
            _AppID = AppID;
            _TestAppID = TestAppID;
            _Trial = Trial - 1;
        }

        private void _LoadData()
        {
            _DLApp = clsLocalDrivingLicenseApplication.Find(_DLAppID);
            _App = clsApplication.Find(_AppID);
            _TestType = clsTestType.Find(1);
            _AppType = clsApplicationType.Find(7);
            _TestAppointment = clsTestAppointment.Find(_TestAppID);
            lblDLAppID.Text = _DLAppID.ToString();
            lblDClass.Text = _DLApp.ClassName;
            lblName.Text = _App.FullName;
            lblFees.Text = _TestType.TestTypeFees.ToString("00");
            lblDate.Text = _TestAppointment.AppointmentDate.ToString("d/MMM/yyyy");
            lblTrial.Text = _Trial.ToString();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            rbPass.Checked = true;
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) 
            {
                _TestAppointment.IsLocked = true;
                _TestAppointment.Save();
                _Test.TestAppointmentID = _TestAppointment.TestAppointmentID;

                if (rbPass.Checked)
                {
                    _DLApp.PassedTestCount++;
                    _DLApp.Save();
                    _Test.TestResult = true;
                }
                if (rbFail.Checked)
                {
                    _Test.TestResult = false;
                }

                _Test.Notes = txtbNotes.Text;
                _Test.CreatedByUserID = GlobalSettings.CurrentUser.UserID;

                if (_Test.Save())
                {
                    lblTestID.Text = _Test.TestID.ToString();
                    rbFail.Enabled = false;
                    rbPass.Enabled = false;
                    btnSave.Enabled = false;
                    txtbNotes.Enabled = false;
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Error : Data was not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
