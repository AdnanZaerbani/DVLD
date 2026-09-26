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
    public partial class frmRenewLocalLicense : Form
    {
        int _OldLicenseID;
        string _NationalNo;
        clsApplication _NewApplication = new clsApplication();
        clsLicense _OldLicense = new clsLicense();
        clsLicense _NewLicense = new clsLicense();
        clsPerson _Person = new clsPerson();
        clsLicenseClass _LicenseClass = new clsLicenseClass();
        public frmRenewLocalLicense()
        {
            InitializeComponent();
            lblRLApplicationID.Text = "[???]";
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(10).ToString("dd/MMM/yyyy");
            lblApplicationFees.Text = clsApplicationType.Find(2).ApplicationFees.ToString("00");//Renew License
            lblLicenseFees.Text = "[$$$]";
            lblRenewedLicenseID.Text = "[???]";
            lblTotalFees.Text = "[$$$]";
            lblOldLicenseID.Text = "[???]";
            lblCreatedBy.Text = GlobalSettings.CurrentUser.UserName;
            ctrlDriverLicenseInfoWithFilter1.SearchFailed += CtrlDriverLicenseInfoWithFilter1_SearchFailed;
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

            if (_OldLicense.ExpirationDate.Date > DateTime.Today)
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on : " + _OldLicense.ExpirationDate.ToString("dd/MMM/yyyy"), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                llShowLicensesInfo.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.SearchCompleted += CtrlDriverLicenseInfoWithFilter1_SearchCompleted;
                lblOldLicenseID.Text = _OldLicenseID.ToString();
                lblTotalFees.Text = "[$$$]";
                lblLicenseFees.Text = "[$$$]";
            }
            else
            {
                btnRenew.Enabled = true;
                llShowLicensesHistory.Enabled = true;
                llShowLicensesInfo.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.SearchCompleted += CtrlDriverLicenseInfoWithFilter1_SearchCompleted;
                lblOldLicenseID.Text = _OldLicenseID.ToString();
                _LicenseClass = clsLicenseClass.Find(_OldLicense.ClassName);
                lblLicenseFees.Text = clsLicenseClass.Find(_LicenseClass.LicenseClassID).ClassFees.ToString("00");
                lblTotalFees.Text = (Convert.ToInt32(lblApplicationFees.Text) + Convert.ToInt32(lblLicenseFees.Text)).ToString("00");
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

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license? ","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Person = clsPerson.Find(_NationalNo);
                _NewApplication.ApplicantPersonID = _Person.PersonID;
                _NewApplication.ApplicationDate = DateTime.Now;
                _NewApplication.ApplicationTypeID = clsApplicationType.Find(2).ApplicationTypeID;
                _NewApplication.ApplicationStatus = 1;//New
                _NewApplication.LastStatusDate = DateTime.Now;
                _NewApplication.PaidFees = clsApplicationType.Find(2).ApplicationFees;
                _NewApplication.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
                if (_NewApplication.Save())
                {
                    _NewLicense.ApplicationID = _NewApplication.ApplicationID;
                    _NewLicense.DriverID = _OldLicense.DriverID;
                    _NewLicense.LicenseClass = clsLicenseClass.Find(_OldLicense.ClassName).LicenseClassID;
                    _NewLicense.IssueDate = DateTime.Now;
                    _NewLicense.ExpirationDate = _NewLicense.IssueDate.AddYears(10);
                    _NewLicense.Notes = txtbNotes.Text;
                    _NewLicense.PaidFees = clsLicenseClass.Find(_LicenseClass.LicenseClassID).ClassFees;
                    _OldLicense.IsActive = false;
                    _OldLicense.UpdateLicenseActive();
                    _NewLicense.IsActive = true;
                    _NewLicense.IssueReason = 2;//Renew
                    _NewLicense.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
                    if (_NewLicense.Save())
                    {
                        MessageBox.Show("License Renewed Successfully with ID = " + _NewLicense.LicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblRLApplicationID.Text = _NewApplication.ApplicationID.ToString();
                        lblRenewedLicenseID.Text = _NewLicense.LicenseID.ToString();
                        llShowLicensesInfo.Enabled = true;
                        btnRenew.Enabled = false;
                        txtbNotes.Enabled = false;
                        ctrlDriverLicenseInfoWithFilter1.Enabled = false;
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
