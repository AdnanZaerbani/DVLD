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
    public partial class frmReleaseDetainedLicense : Form
    {
        int _LicenseID;
        string _NationalNo;
        clsLicense _License = new clsLicense();
        clsLicense _LicenseApp = new clsLicense();
        clsPerson _Person = new clsPerson();
        clsDetainedLicense _DetainLicense = new clsDetainedLicense();
        clsUser _User = new clsUser();
        clsApplicationType _ApplicationType = new clsApplicationType();
        clsApplication _Application = new clsApplication();
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
            lblDetainID.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblDetainDate.Text = "[??/??/????]";
            lblCreatedBy.Text = "[????]";
            lblApplicationFees.Text = "[$$$$]";
            lblFineFees.Text = "[$$$$]";
            lblTotalFees.Text = "[$$$$]";
            lblApplicationID.Text = "[???]";
            ctrlDriverLicenseInfoWithFilter1.SearchFailed += CtrlDriverLicenseInfoWithFilter1_SearchFailed;
        }

        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            lblDetainID.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblDetainDate.Text = "[??/??/????]";
            lblCreatedBy.Text = "[????]";
            lblApplicationFees.Text = "[$$$$]";
            lblFineFees.Text = "[$$$$]";
            lblTotalFees.Text = "[$$$$]";
            lblApplicationID.Text = "[???]";
            ctrlDriverLicenseInfoWithFilter1.SearchFailed += CtrlDriverLicenseInfoWithFilter1_SearchFailed;
            ctrlDriverLicenseInfoWithFilter1.LoadLicense(LicenseID);
            btnRelease.Enabled = true;
        }

        private void CtrlDriverLicenseInfoWithFilter1_SearchFailed(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.FindLicense(_LicenseID);
            _LicenseApp = clsLicense.FindLicenseApplication(_LicenseID);

            if (_License.IsActive == false)
            {
                MessageBox.Show("Selected License is not Active, choose an active license. ", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblLicenseID.Text = _LicenseID.ToString();
                ctrlDriverLicenseInfoWithFilter1.SearchCompleted += CtrlDriverLicenseInfoWithFilter1_SearchCompleted;
                btnRelease.Enabled = false;
                return;
            }

            if (!clsDetainedLicense.IsLicenseDetain(_LicenseID))
            {
                MessageBox.Show("Selected License is not detained, choose another one. ", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlDriverLicenseInfoWithFilter1.SearchCompleted += CtrlDriverLicenseInfoWithFilter1_SearchCompleted;
                lblLicenseID.Text = _LicenseID.ToString();
                btnRelease.Enabled = false;
                return;
            }
            _DetainLicense = clsDetainedLicense.Find(_LicenseID);
            lblDetainID.Text = _DetainLicense.DetainID.ToString();
            lblDetainDate.Text = _DetainLicense.DetainDate.ToString("dd/MMM/yyyy");
            _User = clsUser.Find(_DetainLicense.CreatedByUserID);
            lblCreatedBy.Text = _User.UserName;
            _ApplicationType = clsApplicationType.Find(5);//Detain
            lblApplicationFees.Text = _ApplicationType.ApplicationFees.ToString("00");
            lblFineFees.Text = _DetainLicense.FineFees.ToString("00");
            lblTotalFees.Text = (Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal(lblFineFees.Text)).ToString("00");
            btnRelease.Enabled = true;
            llShowLicensesHistory.Enabled = true;
            llShowLicensesInfo.Enabled = false;
            lblLicenseID.Text = _LicenseID.ToString();
            ctrlDriverLicenseInfoWithFilter1.SearchCompleted += CtrlDriverLicenseInfoWithFilter1_SearchCompleted;
        }

        private void CtrlDriverLicenseInfoWithFilter1_SearchCompleted(string NationaNo)
        {
            _NationalNo = NationaNo;
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Person = clsPerson.Find(_NationalNo);
            frmLicenseHistory frmLicenseHistory = new frmLicenseHistory(_Person.PersonID);
            frmLicenseHistory.ShowDialog();
        }

        private void llShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frmLicenseInfo = new frmLicenseInfo(_LicenseApp.ApplicationID);
            frmLicenseInfo.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detain license? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Person = clsPerson.Find(_NationalNo);
                _Application.ApplicantPersonID = _Person.PersonID;
                _Application.ApplicationDate = DateTime.Now;
                _ApplicationType = clsApplicationType.Find(5);
                _Application.ApplicationTypeID = _ApplicationType.ApplicationTypeID;
                _Application.ApplicationStatus = 1;//New
                _Application.LastStatusDate = DateTime.Now;
                _Application.PaidFees = _ApplicationType.ApplicationFees;
                _Application.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
                if (_Application.Save())
                {
                    _DetainLicense.LicenseID = _LicenseID;
                    _DetainLicense.IsReleased = true;
                    _DetainLicense.ReleaseApplicationID = _Application.ApplicationID;
                    _DetainLicense.UpdateDetainRelease();
                    if (_DetainLicense.Save())
                    {
                        MessageBox.Show("License Detained released Successfully. ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblApplicationID.Text = _Application.ApplicationID.ToString();
                        btnRelease.Enabled = false;
                        ctrlDriverLicenseInfoWithFilter1.Enabled = false;
                        llShowLicensesInfo.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Data storage error", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
