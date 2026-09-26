using DVLD_System___BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class frmUpdateApplicationType : Form
    {
        public frmUpdateApplicationType()
        {
            InitializeComponent();
        }

        bool _ApplicationTypeTitleValid = false;
        bool _ApplicationFeesValid = false;

        int _ApplicationTypeID;
        clsApplicationType _ApplicationType;
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
            _LoadData();
        }

        private void _LoadData()
        {
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);
            lblIDNum.Text = _ApplicationTypeID.ToString();
            txtbTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtbFees.Text = _ApplicationType.ApplicationFees.ToString("0.##");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtbTitle.Enabled = false;
            txtbFees.Enabled = false;
            btnSave.Enabled = false;
            _ApplicationType.ApplicationTypeTitle = txtbTitle.Text;
            _ApplicationType.ApplicationFees = Convert.ToDecimal(txtbFees.Text);

            if (_ApplicationType.Save())
            {
                MessageBox.Show("The edit has been saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Error: Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void CheckAllFields()
        {
            btnSave.Enabled = _ApplicationTypeTitleValid && _ApplicationFeesValid;
        }

        private void txtbTitle_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbTitle.Text))
            {
                epError.SetError(txtbTitle, "This field cannot be empty");
                return;
            }
            else
            {
                epError.SetError(txtbTitle, "");
                _ApplicationTypeTitleValid = true;
            }
            CheckAllFields();
        }

        private void txtbFees_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbFees.Text))
            {
                epError.SetError(txtbFees, "This field cannot be empty");
                return;
            }
            else
            {
                epError.SetError(txtbFees, "");
                _ApplicationFeesValid = true;
            }

            foreach (char c in txtbFees.Text)
            {
                if (!char.IsDigit(c))
                {
                    epError.SetError(txtbFees, "Only numbers are allowed");
                    return;
                }
                else
                {
                    epError.SetError(txtbFees, "");
                    _ApplicationFeesValid = true;
                }
            }
            CheckAllFields();
        }
    }
}
