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
    public partial class frmNewInternationalLicenseApplication : Form
    {
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
            ctrlDriverLicenseInfoWithFilter1.SearchCompleted += CtrlDriverLicenseInfoWithFilter1_SearchCompleted;
        }

        private void CtrlDriverLicenseInfoWithFilter1_SearchCompleted(string NationaNo)
        {
            _NationalNo = NationaNo;
            btnIssue.Enabled = true;
            llShowLicensesHistory.Enabled = true;
            llShowLicensesInfo.Enabled = false;
        }
        int _PersonID;
        int _IntLicenseID;
        string _NationalNo;
        int _LicenseID;
        clsPerson _Person;
        clsApplication _Application = new clsApplication();
        clsApplicationType _AppType;
        clsLicense _License = new clsLicense();
        clsInternationalLicense _InternationalLicense = new clsInternationalLicense();

        private bool _IssueLicense()
        {
            bool _DataSaved = false;
            _Person = clsPerson.Find(_NationalNo);
            _PersonID = _Person.PersonID;
            _Application.ApplicantPersonID = _Person.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = _AppType.ApplicationTypeID;
            _Application.ApplicationStatus = 1;//New
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = _AppType.ApplicationFees;
            _Application.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
            if (!_Application.Save())
            {
                MessageBox.Show("Application Data is not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _DataSaved = false;
                return _DataSaved;
            }

            _LicenseID = ctrlDriverLicenseInfoWithFilter1.LicesneID;
            _License = clsLicense.FindLicense(_LicenseID);
            _InternationalLicense.ApplicationID = _Application.ApplicationID;
            _InternationalLicense.DriverID = _License.DriverID;
            _InternationalLicense.IssuedUsingLocalLicenseID = _License.LicenseID;
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.ExpirationDate = _InternationalLicense.IssueDate.AddYears(1);
            _InternationalLicense.IsActive = true;
            _InternationalLicense.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
            if (_InternationalLicense.Save())
            {
                lbIILApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                lblILLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
                _IntLicenseID = _InternationalLicense.InternationalLicenseID;
                _DataSaved = true;
                return _DataSaved;
            }
            else
            {
                _DataSaved = false;
                return _DataSaved;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _AppType = clsApplicationType.Find(6);
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblFees.Text = _AppType.ApplicationFees.ToString("00");
            lblExpirationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedByUser.Text = GlobalSettings.CurrentUser.UserName;
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Person = clsPerson.Find(_NationalNo);
            frmLicenseHistory frmLicenseHistory = new frmLicenseHistory(_Person.PersonID);
            frmLicenseHistory.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _LicenseID = ctrlDriverLicenseInfoWithFilter1.LicesneID;
            if (clsDetainedLicense.IsLicenseDetain(_LicenseID))
            {
                MessageBox.Show("Selected License is already detained, choose another one. ", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsInternationalLicense.IsPersonHasIntLicenseID(_LicenseID))
            {
                _InternationalLicense = clsInternationalLicense.FindIntLicense(_LicenseID);
                _IntLicenseID = _InternationalLicense.InternationalLicenseID;
                _Person = clsPerson.Find(_NationalNo);
                _PersonID = _Person.PersonID;
                MessageBox.Show("Person already have an active international license with ID = " + _InternationalLicense.InternationalLicenseID.ToString() , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llShowLicensesInfo.Enabled = true;
                btnIssue.Enabled = false;
            }
            else
            {
                if (_IssueLicense())
                {
                    MessageBox.Show("The international license was successfully issued", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llShowLicensesInfo.Enabled = true;
                    btnIssue.Enabled = false;
                    ctrlDriverLicenseInfoWithFilter1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Data storage error", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void llShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalDriverInfo frmInternationalDriverInfo = new frmInternationalDriverInfo(_IntLicenseID, _PersonID);
            frmInternationalDriverInfo.ShowDialog();
        }
    }
}
