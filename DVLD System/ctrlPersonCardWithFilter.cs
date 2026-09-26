using DVLD_System.Properties;
using DVLD_System___BusinessLayer;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _PersonID = -1;
        string _NationalNo = "";
        clsPerson _Person;

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public ctrlPersonCardWithFilter(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            if (_PersonID == -1)
                _Mode = enMode.AddNew;
            else
            {
                _Mode = enMode.Update;
            }
        }

        public ctrlPersonCardWithFilter(string NationalNo)
        {
            InitializeComponent();

            _NationalNo = NationalNo;
        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;

            if (_PersonID == -1)
                _Mode = enMode.AddNew;
            else
            {
                _Mode = enMode.Update;
                _LoadPersonData();
            }
        }

        private void _LoadPersonData()
        {
            _Person = null;
            

            // Search by PersonID
            if (_PersonID != -1)
            {
                _Person = clsPerson.Find(_PersonID);
                llEditPersonInfo.Enabled = true;
            }

            // Search by NationalNo
            else if (!string.IsNullOrWhiteSpace(_NationalNo))
            {
                _Person = clsPerson.Find(_NationalNo);
                llEditPersonInfo.Enabled = true;

                if (_Person != null)
                {
                    _PersonID = _Person.PersonID;
                }
            }

            // Person not found
            if (_Person == null)
            {
                MessageBox.Show("Person not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblPersonID.Text = "[????]";
                lblName.Text = "[????]";
                lblNationalNo.Text = "[????]";
                lblGender.Text = "[????]";
                lblEmail.Text = "[????]";
                lblAddress.Text = "[????]";
                lblDateOfBirth.Text = "[????]";
                lblPhone.Text = "[????]";
                lblCountry.Text = "[????]";
                pbImage.Image = Resources.Male_512;
                return;
            }

            lblPersonID.Text = _Person.PersonID.ToString();

            lblName.Text = string.Join(" ", new[] { _Person.FirstName, _Person.SecondName, _Person.ThirdName, _Person.LastName }.Where(x => !string.IsNullOrWhiteSpace(x)));

            lblNationalNo.Text = _Person.NationalNo;

            // Gender
            if (_Person.Gender == 0)
            {
                lblGender.Text = "Male";
                pbGender.Image = Resources.Man_32;
            }
            else if (_Person.Gender == 1)
            {
                lblGender.Text = "Female";
                pbGender.Image = Resources.Woman_32;
            }

            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString("dd/MM/yyyy");
            lblPhone.Text = _Person.Phone;

            // Country
            clsCountry Country = clsCountry.Find(_Person.NationalityCountryID);

            if (Country != null)
            {
                lblCountry.Text = Country.CountryName;
            }

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                string peopleFolder = Path.Combine(
                    Application.StartupPath,
                    "People-Images"
                );

                if (Directory.Exists(peopleFolder))
                {
                    string[] files = Directory.GetFiles(peopleFolder,_Person.ImagePath + ".*");

                    if (files.Length > 0)
                    {
                        pbImage.ImageLocation = files[0];
                    }
                    else
                    {
                        _SetDefaultImage();
                    }
                }
                else
                {
                    _SetDefaultImage();
                }
            }
            else
            {
                _SetDefaultImage();
            }
        }
        
        private void _SetDefaultImage()
        {
            if (_Person.Gender == 0)
            {
                pbImage.Image = Resources.Male_512;
            }
            else if (_Person.Gender == 1)
            {
                pbImage.Image = Resources.Female_512;
            }
        }

        public void LoadPersonInfoByPersonID(int PersonID)
        {
            _PersonID = PersonID;
            _NationalNo = "";
            _Mode = enMode.Update; 
            _LoadPersonData();
        }

        public void LoadPersonInfoByNationalNo(string NationalNo)
        {
            _NationalNo = NationalNo;
            _PersonID = -1;

            _LoadPersonData();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbFilter.Clear();
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtbFilter.Visible = false;
                btnFindPerson.Enabled = false;
            }
            else
            {
                txtbFilter.Visible = true;
                btnFindPerson.Enabled = true;

                txtbFilter.Focus();
            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                return;
            }

            // Search by Person ID
            if (cbFilterBy.SelectedIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(txtbFilter.Text))
                {
                    MessageBox.Show("Please enter Person ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtbFilter.Focus();
                    return;
                }

                if (!int.TryParse(txtbFilter.Text, out int PersonID))
                {
                    MessageBox.Show("Person ID must contain numbers only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtbFilter.Focus();
                    return;
                }

                LoadPersonInfoByPersonID(PersonID);
            }


            // Search by National Number
            else if (cbFilterBy.SelectedIndex == 2)
            {
                if (string.IsNullOrWhiteSpace(txtbFilter.Text))
                {
                    MessageBox.Show("Please enter National Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtbFilter.Focus();
                    return;
                }

                LoadPersonInfoByNationalNo(txtbFilter.Text.Trim());
            }
        }

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Person ID
            if (cbFilterBy.SelectedIndex == 1)
            {
                if (!char.IsDigit(e.KeyChar) &&
                    !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Person == null)
            {
                return;
            }

            frmAddEditPerson frm = new frmAddEditPerson(_Person.PersonID);

            frm.ShowDialog();

            // Reload the person information after editing
            LoadPersonInfoByPersonID(_Person.PersonID);
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            

            if (_Mode == enMode.Update)
            {
                cbFilterBy.SelectedIndex = 1;
                txtbFilter.Visible = true;
                cbFilterBy.Enabled = false;
                txtbFilter.Enabled = false;
                btnAddNewUser.Enabled = false;
                btnFindPerson.Enabled = false;
                txtbFilter.Text = _PersonID.ToString();
            }
            else
            {
                cbFilterBy.SelectedIndex = 0;

                txtbFilter.Visible = false;
                btnFindPerson.Enabled = false;
            }
        }

        public int GetPersonID()
        {
            return _PersonID;
        }

        public string GetNationalNo()
        {
            _NationalNo = _Person.NationalNo;
            return _NationalNo;
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAddEditPerson = new frmAddEditPerson();
            frmAddEditPerson.ShowDialog();
        }

        private void gbPersonInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}