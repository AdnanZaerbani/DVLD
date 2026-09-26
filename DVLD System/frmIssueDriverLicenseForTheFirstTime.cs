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
    public partial class frmIssueDriverLicenseForTheFirstTime : Form
    {
        public frmIssueDriverLicenseForTheFirstTime()
        {
            InitializeComponent();
        }
        int _DLAppID;
        int _AppID;
        clsApplication _App;
        clsLocalDrivingLicenseApplication _DLApp;
        clsDriver _Driver = new clsDriver();
        clsLicense _License = new clsLicense();
        public frmIssueDriverLicenseForTheFirstTime(int DLAppID, int ApplicationID)
        {
            InitializeComponent();
            _DLAppID = DLAppID;
            _AppID = ApplicationID;
            ctrlTestAppointment1.LoadInfo(_DLAppID, _AppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _App = clsApplication.Find(_AppID);
            _DLApp = clsLocalDrivingLicenseApplication.Find(_DLAppID, "");

            _Driver.PersonID = _App.ApplicantPersonID;
            _Driver.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
            _Driver.CreatesDate = DateTime.Now;
            _Driver.Save();

            _License.ApplicationID = _App.ApplicationID;
            _License.DriverID = _Driver.DriverID;
            _License.LicenseClass = _DLApp.LicenseClassID;
            _License.IssueDate = DateTime.Now;
            _License.ExpirationDate = _License.IssueDate.AddYears(10);
            _License.Notes = txtbNotes.Text;
            _License.PaidFees = _App.AppFees;
            _License.IsActive = true;
            _License.IssueReason = 1;
            _License.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
            if (_License.Save())
            {
                _App.UpdateApplicationStatus(_AppID, 3);
                MessageBox.Show("License Issued Successfully with License ID = " + _License.LicenseID, "Succeede", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error : Data was not saverd", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
