using DVLD_System.Properties;
using DVLD_System___BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Contracts;

namespace DVLD_System
{
    public partial class ctrlAddEditPersonCard : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        bool _FirstNameValid = false;
        bool _SecondNameValid = false;
        bool _LastNameValid = false;
        bool _NationalNoValid = false;
        bool _PhoneValid = false;
        bool _AddressValid = false;

        private bool _IsImageChanged = false;

        int _PersonID;
        string _NationalNo;
        clsPerson _Person;

        private void txtbFirst_Validated(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (string.IsNullOrWhiteSpace(txtbFirst.Text))
                {
                    epError.SetError(txtbFirst, "This field cannot be empty");
                    return;
                }
                else
                {
                    epError.SetError(txtbFirst, "");
                    _FirstNameValid = true;
                }

                foreach (char c in txtbFirst.Text)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        epError.SetError(txtbFirst, "Only letters are allowed");
                        return;
                    }
                    else
                    {
                        epError.SetError(txtbFirst, "");
                        _FirstNameValid = true;
                    }
                }

                CheckAllFields();
            }

            if (_Mode == enMode.Update)
            {
                if (string.IsNullOrWhiteSpace(txtbFirst.Text))
                {
                    epError.SetError(txtbFirst, "This field cannot be empty");
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    epError.SetError(txtbFirst, "");
                    btnSave.Enabled = true;

                }

                foreach (char c in txtbFirst.Text)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        epError.SetError(txtbFirst, "Only letters are allowed");
                        btnSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        epError.SetError(txtbFirst, "");
                        btnSave.Enabled = true;
                    }
                }
            }
        }

        private void txtbSecond_Validated(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (string.IsNullOrWhiteSpace(txtbSecond.Text))
                {
                    epError.SetError(txtbSecond, "This field cannot be empty");
                    return;
                }
                else
                {
                    epError.SetError(txtbSecond, "");
                    _SecondNameValid = true;
                }

                foreach (char c in txtbSecond.Text)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        epError.SetError(txtbSecond, "Only letters are allowed");
                        return;
                    }
                    else
                    {
                        epError.SetError(txtbSecond, "");
                        _SecondNameValid = true;
                    }
                }

                CheckAllFields();
            }

            if (_Mode == enMode.Update)
            {
                if (string.IsNullOrWhiteSpace(txtbSecond.Text))
                {
                    epError.SetError(txtbSecond, "This field cannot be empty");
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    epError.SetError(txtbSecond, "");
                    btnSave.Enabled = true;
                }

                foreach (char c in txtbSecond.Text)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        epError.SetError(txtbSecond, "Only letters are allowed");
                        btnSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        epError.SetError(txtbSecond, "");
                        btnSave.Enabled = true;
                    }
                }
            }
        }

        private void txtbThird_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbThird.Text))
            {
                epError.SetError(txtbThird, "");
            }

            foreach (char c in txtbThird.Text)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    epError.SetError(txtbThird, "Only letters are allowed");
                    return;
                }
                else
                {
                    epError.SetError(txtbThird, "");
                }
            }

            if (_Mode == enMode.Update)
            {
                if (string.IsNullOrWhiteSpace(txtbThird.Text))
                {
                    epError.SetError(txtbThird, "");
                    btnSave.Enabled = true;
                }

                foreach (char c in txtbThird.Text)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        epError.SetError(txtbThird, "Only letters are allowed");
                        btnSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        epError.SetError(txtbThird, "");
                        btnSave.Enabled = true;
                    }
                }
            }
        }

        private void txtbLast_Validated(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (string.IsNullOrWhiteSpace(txtbLast.Text))
                {
                    epError.SetError(txtbLast, "This field cannot be empty");
                    return;
                }
                else
                {
                    epError.SetError(txtbLast, "");
                    _LastNameValid = true;
                }

                foreach (char c in txtbLast.Text)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        epError.SetError(txtbLast, "Only letters are allowed");
                        return;
                    }
                    else
                    {
                        epError.SetError(txtbLast, "");
                        _LastNameValid = true;
                    }
                }

                CheckAllFields();
            }

            if (_Mode == enMode.Update)
            {
                if (string.IsNullOrWhiteSpace(txtbLast.Text))
                {
                    epError.SetError(txtbLast, "This field cannot be empty");
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    epError.SetError(txtbLast, "");
                    btnSave.Enabled = true;
                }

                foreach (char c in txtbLast.Text)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        epError.SetError(txtbLast, "Only letters are allowed");
                        btnSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        epError.SetError(txtbLast, "");
                        btnSave.Enabled = true;
                    }
                }
            }
        }

        private void txtbNationalNo_Validated(object sender, EventArgs e)
        {
            string NationalNum = txtbNationalNo.Text.ToString();

            if (_Mode == enMode.AddNew)
            {
                if (clsPerson.IsPersonExist(NationalNum))
                {
                    epError.SetError(txtbNationalNo, "National Number is used for another person!");
                    return;
                }
                else
                {
                    epError.SetError(txtbNationalNo, "");
                    _NationalNoValid = true;
                }

                if (string.IsNullOrWhiteSpace(txtbNationalNo.Text))
                {
                    epError.SetError(txtbNationalNo, "This field cannot be empty");
                    return;
                }
                else
                {
                    epError.SetError(txtbNationalNo, "");
                    _NationalNoValid = true;
                }

                foreach (char c in txtbNationalNo.Text)
                {
                    if (!char.IsDigit(c))
                    {
                        epError.SetError(txtbNationalNo, "Only numbers are allowed");
                        return;
                    }
                    else
                    {
                        epError.SetError(txtbNationalNo, "");
                        _NationalNoValid = true;
                    }
                }

                if (NationalNum.Length != 11)
                {
                    epError.SetError(txtbNationalNo, "Must contain exactly 11 digits");
                }
                else
                {
                    epError.SetError(txtbNationalNo, "");
                    _NationalNoValid = true;
                }

                CheckAllFields();
            }

            if (_Mode == enMode.Update)
            {
                NationalNum = txtbNationalNo.Text.ToString();

                if (clsPerson.IsPersonExist(NationalNum) && (_NationalNo == txtbNationalNo.Text.ToString()))
                {
                    epError.SetError(txtbNationalNo, "");
                    btnSave.Enabled = true;
                    return;
                }
                else if (clsPerson.IsPersonExist(NationalNum))
                {
                    epError.SetError(txtbNationalNo, "National Number is used for another person!");
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    epError.SetError(txtbNationalNo, "");
                    btnSave.Enabled = true;
                }

                if (string.IsNullOrWhiteSpace(txtbNationalNo.Text))
                {
                    epError.SetError(txtbNationalNo, "This field cannot be empty");
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    epError.SetError(txtbNationalNo, "");
                    btnSave.Enabled = true;
                }

                foreach (char c in txtbNationalNo.Text)
                {
                    if (!char.IsDigit(c))
                    {
                        epError.SetError(txtbNationalNo, "Only numbers are allowed");
                        btnSave.Enabled = false;
                        return;
                    }
                }

                if (NationalNum.Length != 11)
                {
                    epError.SetError(txtbNationalNo, "Must contain exactly 11 digits");
                    btnSave.Enabled = false;
                }
                else
                {
                    epError.SetError(txtbNationalNo, "");
                    btnSave.Enabled = true;
                }
            }
        }

        private void txtbEmail_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbEmail.Text))
            {
                epError.SetError(txtbEmail, "");
            }
            else
            {
                if (!txtbEmail.Text.EndsWith("@gmail.com"))
                {
                    epError.SetError(txtbEmail, "Email must end with @gmail.com");
                    return;
                }
                else
                {
                    epError.SetError(txtbEmail, "");
                }
            }

            if (_Mode == enMode.Update)
            {
                if (string.IsNullOrWhiteSpace(txtbEmail.Text))
                {
                    epError.SetError(txtbEmail, "");
                    btnSave.Enabled = true;
                }
                else
                {
                    if (!txtbEmail.Text.EndsWith("@gmail.com"))
                    {
                        epError.SetError(txtbEmail, "Email must end with @gmail.com");
                        btnSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        epError.SetError(txtbEmail, "");
                        btnSave.Enabled = true;
                    }
                }
            }
        }

        private void txtbPhone_Validated(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                string phone = txtbPhone.Text;

                if (phone.Length != 10)
                {
                    epError.SetError(txtbPhone, "Phone number must contain 10 digits.");
                    return;
                }
                else
                {
                    epError.SetError(txtbPhone, "");
                    _PhoneValid = true;
                }

                if (!phone.StartsWith("09"))
                {
                    epError.SetError(txtbPhone, "Phone number must start with 09.");
                    return;
                }
                else
                {
                    epError.SetError(txtbPhone, "");
                    _PhoneValid = true;
                }

                foreach (char c in phone)
                {
                    if (!char.IsDigit(c))
                    {
                        epError.SetError(txtbPhone, "Phone number must contain digits only.");
                        return;
                    }
                    else
                    {
                        epError.SetError(txtbPhone, "");
                        _PhoneValid = true;
                    }
                }
                CheckAllFields();
            }

            if (_Mode == enMode.Update)
            {
                string phone = txtbPhone.Text;

                if (phone.Length != 10)
                {
                    epError.SetError(txtbPhone, "Phone number must contain 10 digits.");
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    epError.SetError(txtbPhone, "");
                    btnSave.Enabled = true;
                }

                if (!phone.StartsWith("09"))
                {
                    epError.SetError(txtbPhone, "Phone number must start with 09.");
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    epError.SetError(txtbPhone, "");
                    btnSave.Enabled = true;
                }

                foreach (char c in phone)
                {
                    if (!char.IsDigit(c))
                    {
                        epError.SetError(txtbPhone, "Phone number must contain digits only.");
                        btnSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        epError.SetError(txtbPhone, "");
                        btnSave.Enabled = true;
                    }
                }
            }
        }

        private void txtbAddress_Validated(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (string.IsNullOrWhiteSpace(txtbAddress.Text))
                {
                    epError.SetError(txtbAddress, "Field cannot be empty");
                    return;
                }
                else
                {
                    epError.SetError(txtbAddress, "");
                    _AddressValid = true;
                }
                CheckAllFields();
            }

            if (_Mode == enMode.Update)
            {
                if (string.IsNullOrWhiteSpace(txtbAddress.Text))
                {
                    epError.SetError(txtbAddress, "Field cannot be empty");
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    epError.SetError(txtbAddress, "");
                    btnSave.Enabled = true;
                }
            }
        }

        private void CheckAllFields()
        {
            btnSave.Enabled =
               _FirstNameValid &&
               _SecondNameValid &&
               _LastNameValid &&
               _NationalNoValid &&
               _PhoneValid &&
               _AddressValid;
        }

        public ctrlAddEditPersonCard()
        {
            InitializeComponent();
            if (_PersonID == 0)
            {
                _Mode = enMode.AddNew;
                _LoadData();
            }
            else
            {
                _Mode = enMode.Update;
            }
        }

        public ctrlAddEditPersonCard(int PersonID)
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

        private void _FillCountriesInComoboBox()
        {
            foreach (DataRow row in clsCountry.GetAllCountries().Rows)
            {
                cbCountry.Items.Add(row[0].ToString());
            }
        }

        private void _LoadData()
        {
            _FillCountriesInComoboBox();
            btnSave.Enabled = true;
            cbCountry.SelectedItem = "Syria";
            rbMale.Checked = true;
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            if (_Mode == enMode.AddNew)
            {
                lblTitleMod.Text = "Add New Person";
                _Person = new clsPerson();
                return;
            }

            _Person = clsPerson.Find(_PersonID);
            
            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            _NationalNo = _Person.NationalNo;

            lblTitleMod.Text = "Update Person";
            lblPersonID.Text = _PersonID.ToString();
            txtbFirst.Text = _Person.FirstName;
            txtbSecond.Text = _Person.SecondName;
            txtbThird.Text = _Person.ThirdName;
            txtbLast.Text = _Person.LastName;
            txtbNationalNo.Text = _Person.NationalNo;
            txtbPhone.Text = _Person.Phone;
            txtbEmail.Text = _Person.Email;
            txtbAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                string peopleFolder = Path.Combine(
                    Application.StartupPath,
                    "People-Images"
                );

                string[] files = Directory.GetFiles(
                    peopleFolder,
                    _Person.ImagePath + ".*"
                );

                if (files.Length > 0)
                {
                    pbImage.ImageLocation = files[0];
                    llRemove.Visible = true;
                }
            }

            if (_Person.Gender == 0)
            {
                rbMale.Checked = true;
            }
            if (_Person.Gender == 1)
            {
                rbFemale.Checked = true;
            }

            llRemove.Visible = (_Person.ImagePath != "");

            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Person.NationalityCountryID).CountryName);
        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;

            if (_PersonID == -1)
                _Mode = enMode.AddNew;
            else
            {
                _Mode = enMode.Update;
                _LoadData();
            }
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
            llRemove.Visible = false;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbImage.Image = Resources.Male_512;
        }
        
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbImage.Image = Resources.Female_512;
        }
       
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Process the selected file
                    string selectedFilePath = openFileDialog.FileName;
                    //MessageBox.Show("Selected Image is:" + selectedFilePath);

                    pbImage.Load(selectedFilePath);
                    llRemove.Visible = true;
                    _IsImageChanged = true;
                    if (rbFemale.Checked)
                    {
                        rbMale.Enabled = false;
                    }

                    if (rbMale.Checked)
                    {
                        rbFemale.Enabled = false;
                    }
                    // ...
                }
            }
        }
        
        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            llRemove.Visible = false;
            _IsImageChanged = false;
            rbMale.Enabled = true;
            rbFemale.Enabled = true;
            if (rbFemale.Checked)
            {
                pbImage.Image = Resources.Female_512;
            }
            else
            {
                pbImage.Image = Resources.Male_512;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {

            txtbFirst.Enabled = false;
            txtbLast.Enabled = false;
            txtbSecond.Enabled = false;
            txtbThird.Enabled = false;
            txtbPhone.Enabled = false;
            txtbEmail.Enabled = false;
            txtbAddress.Enabled = false;
            cbCountry.Enabled = false;
            dtpDateOfBirth.Enabled = false;
            llSetImage.Enabled = false;
            llRemove.Enabled = false;
            rbMale.Enabled = false;
            rbFemale.Enabled = false;
            txtbNationalNo.Enabled = false;
            int Country = clsCountry.Find(cbCountry.Text).CountryID;
            
            _Person.NationalityCountryID = Country;
            _Person.FirstName = txtbFirst.Text;
            _Person.SecondName = txtbSecond.Text;
            _Person.LastName = txtbLast.Text;
            _Person.Address = txtbAddress.Text;
            _Person.NationalNo = txtbNationalNo.Text;
            _Person.Phone = txtbPhone.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            if (rbFemale.Checked)
                _Person.Gender = 1;
            else
                _Person.Gender = 0;

            if (!string.IsNullOrWhiteSpace(txtbThird.Text))
                _Person.ThirdName = txtbThird.Text;
            else
                _Person.ThirdName = "";

            if (!string.IsNullOrWhiteSpace(txtbEmail.Text))
                _Person.Email = txtbEmail.Text;
            else
                _Person.Email = "";

            if (_IsImageChanged)
            {
                string peopleFolder = Path.Combine(
                    Application.StartupPath,
                    "People-Images"
                );

                if (!Directory.Exists(peopleFolder))
                {
                    Directory.CreateDirectory(peopleFolder);
                }

                // =========================================
                // المستخدم حذف الصورة
                // =========================================

                if (pbImage.ImageLocation == null)
                {
                    if (!string.IsNullOrEmpty(_Person.ImagePath))
                    {
                        string[] oldImages = Directory.GetFiles(
                            peopleFolder,
                            _Person.ImagePath + ".*"
                        );

                        foreach (string oldImage in oldImages)
                        {
                            File.Delete(oldImage);
                        }
                    }

                    _Person.ImagePath = "";
                }

                // =========================================
                // المستخدم اختار صورة جديدة
                // =========================================

                else
                {
                    string selectedImagePath = pbImage.ImageLocation;

                    // الشخص عنده صورة قديمة
                    if (!string.IsNullOrEmpty(_Person.ImagePath))
                    {
                        string[] oldImages = Directory.GetFiles(
                            peopleFolder,
                            _Person.ImagePath + ".*"
                        );

                        string extension =
                            Path.GetExtension(selectedImagePath);

                        string newFileName =
                            _Person.ImagePath + extension;

                        string destinationPath =
                            Path.Combine(peopleFolder, newFileName);

                        // مهم: انسخ الصورة الجديدة أولاً
                        File.Copy(
                            selectedImagePath,
                            destinationPath,
                            true
                        );

                        // بعد نجاح النسخ احذف القديمة
                        foreach (string oldImage in oldImages)
                        {
                            if (!string.Equals(
                                oldImage,
                                destinationPath,
                                StringComparison.OrdinalIgnoreCase))
                            {
                                File.Delete(oldImage);
                            }
                        }

                        pbImage.ImageLocation = destinationPath;
                    }

                    // الشخص ما عنده صورة سابقة
                    else
                    {
                        string imageID = Guid.NewGuid().ToString();

                        string extension =
                            Path.GetExtension(selectedImagePath);

                        string fileName =
                            imageID + extension;

                        string destinationPath =
                            Path.Combine(peopleFolder, fileName);

                        File.Copy(
                            selectedImagePath,
                            destinationPath,
                            true
                        );

                        _Person.ImagePath = imageID;

                        pbImage.ImageLocation = destinationPath;
                    }
                }
            }

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                btnSave.Visible = false;
                MessageBox.Show("Data Saved Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtbFirst.Enabled = false;
                txtbLast.Enabled = false;
                txtbEmail.Enabled = false;
                txtbThird.Enabled = false;
                txtbSecond.Enabled = false;
                txtbAddress.Enabled = false;
                txtbPhone.Enabled = false;
                llRemove.Enabled = false;
                llSetImage.Enabled = false;
                cbCountry.Enabled = false;
                rbFemale.Enabled = false;
                rbMale.Enabled = false;
                dtpDateOfBirth.Enabled = false;
                txtbNationalNo.Enabled = false;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            _Mode = enMode.Update;
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }
    }
}
