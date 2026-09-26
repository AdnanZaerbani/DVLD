using DVLD_System.Properties;
using DVLD_System___BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
            
        }

        public event Action<string> SearchCompleted;

        public event Action<int> SearchFailed;

        public int LicesneID
        {
            get { return _License.LicenseID; }
        }
        clsLicense _License = new clsLicense();

        private void _LoadLicenseInfo()
        {
            _License = clsLicense.FindLicense(Convert.ToInt32(txtbLicenseID.Text));
            if (_License == null)
            {
                MessageBox.Show("License is not found with ID = " + txtbLicenseID.Text, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SearchFailed?.Invoke(_License.LicenseID);
            SearchCompleted?.Invoke(_License.NationalNo);
            lblClass.Text = _License.ClassName;
            lblFullName.Text = _License.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.NationalNo;
            if (_License.Gender == 0)
            {
                lblGender.Text = "Male";
                pbGender.Image = Resources.Man_32;
            }

            if (_License.Gender == 1)
            {
                lblGender.Text = "Female";
                pbGender.Image = Resources.Woman_32;
            }

            lblIssueDate.Text = _License.IssueDate.ToString("dd/MMM/yyyy");

            if (_License.IssueReason == 1)
            {
                lblIssueReason.Text = "First Time";
            }

            if (_License.IssueReason == 2)
            {
                lblIssueReason.Text = "Renew";
            }

            if (_License.IssueReason == 3)
            {
                lblIssueReason.Text = "Replacement for Damaged";
            }

            if (_License.IssueReason == 4)
            {
                lblIssueReason.Text = "Replacement for Lost";
            }

            if (_License.IsActive == false)
            {
                lblIsActive.Text = "No";
            }

            if (_License.IsActive == true)
            {
                lblIsActive.Text = "Yes";
            }

            if (string.IsNullOrEmpty(_License.Notes))
            {
                lblNotes.Text = "No Notes";
            }
            else
            {
                lblNotes.Text = _License.Notes;
            }

            lblDateOfBirth.Text = _License.DateOfBirth.ToString("dd/MMM/yyyy");
            lblDiverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString("dd/MMM/yyyy");

            if (clsDetainedLicense.IsLicenseDetain(_License.LicenseID))
            {
                lblIsDetained.Text = "Yes";
            }
            else
            {
                lblIsDetained.Text = "No";
            }
            
            if (!string.IsNullOrEmpty(_License.ImagePath))
            {
                string peopleFolder = Path.Combine(
                    Application.StartupPath,
                    "People-Images"
                );

                string[] files = Directory.GetFiles(
                    peopleFolder,
                    _License.ImagePath + ".*"
                );

                if (files.Length > 0)
                {
                    pbImage.ImageLocation = files[0];
                }
            }
            else
            {
                if (lblGender.Text == "Male")
                {
                    pbImage.Image = Resources.Male_512;
                }

                if (lblGender.Text == "Female")
                {
                    pbImage.Image = Resources.Female_512;
                }
            }
        }

        private void btnFindLicenseID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbLicenseID.Text))
            {
                MessageBox.Show("Please enter License ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtbLicenseID.Focus();
                return;
            }

            if (!int.TryParse(txtbLicenseID.Text, out int PersonID))
            {
                MessageBox.Show("License ID must contain numbers only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtbLicenseID.Focus();
                return;
            }

            _LoadLicenseInfo();
        }

        public void LoadLicense(int License)
        {
            txtbLicenseID.Text = License.ToString();
            gbFilter.Enabled = false;
            _LoadLicenseInfo();
        }
    }
}
