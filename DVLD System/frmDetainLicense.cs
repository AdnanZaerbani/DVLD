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
    public partial class frmDetainLicense : Form
    {
        int _LicenseID;
        string _NationalNo;
        clsLicense _License = new clsLicense();
        clsLicense _LicenseApp = new clsLicense();
        clsPerson _Person = new clsPerson();  
        clsDetainedLicense _DetainLicense = new clsDetainedLicense();
        public frmDetainLicense()
        {
            InitializeComponent();
            lblDetainID.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblDetainDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = GlobalSettings.CurrentUser.UserName;
            ctrlDriverLicenseInfoWithFilter1.SearchFailed += CtrlDriverLicenseInfoWithFilter1_SearchFailed;
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
                return;
            }

            if (clsDetainedLicense.IsLicenseDetain(_LicenseID))
            {
                MessageBox.Show("Selected License is already detained, choose another one. ", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlDriverLicenseInfoWithFilter1.SearchCompleted += CtrlDriverLicenseInfoWithFilter1_SearchCompleted;
                lblLicenseID.Text = _LicenseID.ToString();
                return;
            }

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

        private void btnDeatin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Detain this license? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _DetainLicense.LicenseID = _License.LicenseID;
                _DetainLicense.DetainDate = DateTime.Now;
                _DetainLicense.FineFees = Convert.ToDecimal(txtbFineFees.Text);
                _DetainLicense.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
                _DetainLicense.IsReleased = false;
                if (_DetainLicense.Save())
                {
                    MessageBox.Show("License Detained Successfully with ID = " + _DetainLicense.DetainID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblDetainID.Text = _DetainLicense.DetainID.ToString();
                    txtbFineFees.Enabled = false;
                    btnDeatin.Enabled = false;
                    ctrlDriverLicenseInfoWithFilter1.Enabled = false;
                    llShowLicensesInfo.Enabled = true;
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

        private void txtbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtbFineFees_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbFineFees.Text))
            {
                epError.SetError(txtbFineFees, "This field cannot be empty");
                btnDeatin.Enabled = false;
                return;
            }
            else
            {
                epError.SetError(txtbFineFees, "");
                btnDeatin.Enabled = true;
            }
        }
    }
}
