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
    public partial class frmReplacementForDamagedLicense : Form
    {
        int _OldLicenseID;
        string _NationalNo;
        clsLicense _OldLicense = new clsLicense();
        clsLicense _NewLicense = new clsLicense();
        clsPerson _Person = new clsPerson();
        clsApplication _NewApplication = new clsApplication();
        clsLicenseClass _LicenseClass = new clsLicenseClass();
        int _AppType;
        byte _IssueReason;
        public frmReplacementForDamagedLicense()
        {
            InitializeComponent();
            _IssueReason = 3;
            ctrlDriverLicenseInfoWithFilter1.SearchFailed += CtrlDriverLicenseInfoWithFilter1_SearchFailed;
            rbDamagedLicense.Checked = true;
            lblLRApplicationID.Text = "[???]";
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblApplicationFees.Text = clsApplicationType.Find(4).ApplicationFees.ToString("00");//Replacement for Damaged
            lblReplacedLicenseID.Text = "[???]";
            lblOldLicenseID.Text = "[???]";
            lblCreatedBy.Text = GlobalSettings.CurrentUser.UserName;
        }

        private void CtrlDriverLicenseInfoWithFilter1_SearchFailed(int LicenseID)
        {
            _OldLicenseID = LicenseID;
            _OldLicense = clsLicense.FindLicense(_OldLicenseID);

            if (clsDetainedLicense.IsLicenseDetain(_OldLicenseID))
            {
                MessageBox.Show("Selected License is already detained, choose another one. ", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_OldLicense.IsActive == false)
            {
                MessageBox.Show("Selected License is not Active, choose an active license. ", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                llShowLicensesInfo.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.SearchCompleted += CtrlDriverLicenseInfoWithFilter1_SearchCompleted;
                lblOldLicenseID.Text = _OldLicenseID.ToString();
            }
            else
            {
                btnIssueReplacement.Enabled = true;
                llShowLicensesHistory.Enabled = true;
                llShowLicensesInfo.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.SearchCompleted += CtrlDriverLicenseInfoWithFilter1_SearchCompleted;
                lblOldLicenseID.Text = _OldLicenseID.ToString();
            }
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
            frmLicenseInfo frmLicenseInfo = new frmLicenseInfo(_NewApplication.ApplicationID);
            frmLicenseInfo.ShowDialog();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Replacement for the license? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Person = clsPerson.Find(_NationalNo);
                _NewApplication.ApplicantPersonID = _Person.PersonID;
                _NewApplication.ApplicationDate = DateTime.Now;
                _NewApplication.ApplicationTypeID = clsApplicationType.Find(_AppType).ApplicationTypeID;
                _NewApplication.ApplicationStatus = 1;//New
                _NewApplication.LastStatusDate = DateTime.Now;
                _NewApplication.PaidFees = clsApplicationType.Find(_AppType).ApplicationFees;
                _NewApplication.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
                if (_NewApplication.Save())
                {
                    _NewLicense.ApplicationID = _NewApplication.ApplicationID;
                    _NewLicense.DriverID = _OldLicense.DriverID;
                    _NewLicense.LicenseClass = clsLicenseClass.Find(_OldLicense.ClassName).LicenseClassID;
                    _NewLicense.IssueDate = DateTime.Now;
                    _NewLicense.ExpirationDate = _NewLicense.IssueDate.AddYears(10);
                    _NewLicense.Notes = _OldLicense.Notes;
                    _NewLicense.PaidFees = _OldLicense.PaidFees;
                    _OldLicense.IsActive = false;
                    _OldLicense.UpdateLicenseActive();
                    _NewLicense.IsActive = true;
                    _NewLicense.IssueReason = _IssueReason;//Renew
                    _NewLicense.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
                    if (_NewLicense.Save())
                    {
                        MessageBox.Show("License Replacement Successfully with ID = " + _NewLicense.LicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblLRApplicationID.Text = _NewApplication.ApplicationID.ToString();
                        lblReplacedLicenseID.Text = _NewLicense.LicenseID.ToString();
                        llShowLicensesInfo.Enabled = true;
                        ctrlDriverLicenseInfoWithFilter1.Enabled = false;
                        btnIssueReplacement.Enabled = false;
                        rbDamagedLicense.Enabled = false;
                        rbLostLicense.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Data storage error", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamagedLicense.Checked)
            {
                lblTitleMod.Text = "Replacement for Damaged License";
                _AppType = 4;
                lblApplicationFees.Text = clsApplicationType.Find(_AppType).ApplicationFees.ToString("00");
                _IssueReason = 3;
            }
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLostLicense.Checked)
            {
                lblTitleMod.Text = "Replacement for Lost License";
                _AppType = 3;
                lblApplicationFees.Text = clsApplicationType.Find(_AppType).ApplicationFees.ToString("00");
                _IssueReason = 4;
            }
        }
    }
}
