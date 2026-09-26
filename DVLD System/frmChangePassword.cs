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
    public partial class frmChangePassword : Form
    {
        bool _CurrentPasswordValid = false;
        bool _NewPasswordValid = false;
        bool _ConfirmPasswordValid = false;

        clsUser _User = new clsUser();
        int _UserID = -1;
        public frmChangePassword()
        {
            InitializeComponent();
        }

        public frmChangePassword(int PersonID, int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            ctrlUserCard1.LoadDataInfo(PersonID, UserID);
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);
        }

        private void CheckAllFields()
        {
            btnSave.Enabled = _CurrentPasswordValid && _NewPasswordValid && _ConfirmPasswordValid;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void txtbCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtbCurrentPassword.Text != _User.Password)
            {
                epError.SetError(txtbCurrentPassword, "The current password is wrong");
                _CurrentPasswordValid = false;
                return;
            }
            else
            {
                epError.SetError(txtbCurrentPassword, "");
                _CurrentPasswordValid = true;
                CheckAllFields();
            }
        }
        private void txtbNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbNewPassword.Text))
            {
                epError.SetError(txtbNewPassword, "This field cannot be empty");
                _NewPasswordValid = false;
                return;
            }
            else
            {
                epError.SetError(txtbNewPassword, "");
                _NewPasswordValid = true;
                CheckAllFields();
            }
        }

        private void txtbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbConfirmPassword.Text))
            {
                epError.SetError(txtbConfirmPassword, "This field cannot be empty");
                _ConfirmPasswordValid = false;
                return;
            }
            else
            {
                if (txtbNewPassword.Text != txtbConfirmPassword.Text)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            txtbCurrentPassword.Enabled = false;
            txtbNewPassword.Enabled = false;
            txtbConfirmPassword.Enabled = false;
            _User.Password = txtbNewPassword.Text;
            if (_User.Save())
            {
                MessageBox.Show("The password has been changed successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("The password was not changed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
