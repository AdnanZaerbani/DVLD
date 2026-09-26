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
    public partial class frmUpdateTestType : Form
    {
        public frmUpdateTestType()
        {
            InitializeComponent();
        }

        bool _TestTypeTitlevalid = false;
        bool _TestTypeDescriptionValid = false;
        bool _TestTypeFeesValid = false;

        int _TestTypeID;
        clsTestType _TestType;

        public frmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
            _LoadData();
        }

        private void _LoadData()
        {
            _TestType = clsTestType.Find(_TestTypeID);
            lblIDNum.Text = _TestTypeID.ToString();
            txtbTitle.Text = _TestType.TestTypeTitle;
            txtbDescription.Text = _TestType.TestTypeDescription;
            txtbFees.Text = _TestType.TestTypeFees.ToString("0.##");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtbDescription.Enabled = false;
            txtbTitle.Enabled = false;
            txtbFees.Enabled = false;
            btnSave.Enabled = false;
            _TestType.TestTypeTitle = txtbTitle.Text;
            _TestType.TestTypeDescription = txtbDescription.Text;
            _TestType.TestTypeFees = Convert.ToDecimal(txtbFees.Text);

            if (_TestType.Save())
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
            btnSave.Enabled = _TestTypeTitlevalid && _TestTypeDescriptionValid && _TestTypeFeesValid;
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
                _TestTypeTitlevalid = true;
            }
            CheckAllFields();
        }

        private void txtbDescription_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbDescription.Text))
            {
                epError.SetError(txtbDescription, "This field cannot be empty");
                return;
            }
            else
            {
                epError.SetError(txtbDescription, "");
                _TestTypeDescriptionValid = true;
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
                _TestTypeFeesValid = true;
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
                    _TestTypeFeesValid = true;
                }
            }
            CheckAllFields();
        }
    }
}
