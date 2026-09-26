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
    public partial class frmAddEditUser : Form
    {
        public frmAddEditUser()
        {
            InitializeComponent();
        }

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _UserID = -1;

        public frmAddEditUser(int UserID, int _PersonID)
        {
            InitializeComponent();
            _UserID = UserID;
            if (_UserID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
                ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                _LoadData();
            }
        }

        bool _UserNameValid = false;
        bool _PasswordValid = false;
        bool _ConfirmPasswordValid = false;

        int _PersonID;
        clsUser _User = new clsUser();

        private void _LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                return;
            }
            else
            {
                txtbUserName.Enabled = true;
                txtbPassword.Enabled = true;
                txtbConfirmPassword.Enabled = true;
                chbIsActive.Enabled = true;
                _User = clsUser.Find(_UserID);
                lblTitle.Text = "Update User";
                lblUserID.Text = _UserID.ToString();
                txtbUserName.Text = _User.UserName;
                txtbPassword.Text = _User.Password;
                txtbConfirmPassword.Text = _User.Password;
                if (_User.IsActive == 0)
                {
                    chbIsActive.Checked = false;
                }

                if (_User.IsActive == 1)
                {
                    chbIsActive.Checked = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                _PersonID = ctrlPersonCardWithFilter1.GetPersonID();
                if (_PersonID == -1)
                {
                    MessageBox.Show("Please select a person to become a user.", "Select a person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!clsUser.IsPersonHasUser(_PersonID))
                    {
                        tcAddNewUser.SelectedIndex = 1;
                        txtbUserName.Enabled = true;
                        txtbPassword.Enabled = true;
                        txtbConfirmPassword.Enabled = true;
                        chbIsActive.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Selected Person already has a user, choose another one.", "Select another person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            tcAddNewUser.SelectedIndex = 1;
        }

        private void txtbUserName_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbUserName.Text))
            {
                epError.SetError(txtbUserName, "This field cannot be empty");
                _UserNameValid = false;
                return;
            }
            else
            {
                epError.SetError(txtbUserName, "");
                _UserNameValid = true;
                CheckAllFields();
            }
        }

        private void txtbPassword_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbPassword.Text))
            {
                epError.SetError(txtbPassword, "This field cannot be empty");
                _PasswordValid = false;
                return;
            }
            else
            {
                epError.SetError(txtbPassword, "");
                _PasswordValid = true;
                CheckAllFields();
            }
        }

        private void txtbConfirmPassword_Validated(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtbConfirmPassword.Text))
            {
                epError.SetError(txtbConfirmPassword, "This field cannot be empty");
                _ConfirmPasswordValid = false;
                return;
            }
            else
            {
                if (txtbPassword.Text != txtbConfirmPassword.Text)
                {
                    epError.SetError(txtbConfirmPassword, "The password does not match.");
                    _ConfirmPasswordValid = false;
                    return;
                }
                else
                {
                    epError.SetError(txtbConfirmPassword, "");
                    _ConfirmPasswordValid = true;
                    CheckAllFields();
                }
            }
        }

        private void CheckAllFields()
        {
            btnSave.Enabled = _UserNameValid && _PasswordValid && _ConfirmPasswordValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtbUserName.Enabled = false;
            txtbPassword.Enabled = false;
            txtbConfirmPassword.Enabled = false;
            chbIsActive.Enabled = false;
            _User.PersonID = _PersonID;
            _User.UserName = txtbUserName.Text;
            _User.Password = txtbPassword.Text;
            if (chbIsActive.Checked)
            {
                _User.IsActive = 1;
            }
            else
            {
                _User.IsActive = 0;
            }

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                btnSave.Visible = false;
                MessageBox.Show("Data Saved Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtbUserName.Enabled = false;
                txtbPassword.Enabled = false;
                txtbConfirmPassword.Enabled = false;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
}
