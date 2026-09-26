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
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        int _PersonID = -1;
        short _ApplicationTypeID = 1;
        clsApplication _Application = new clsApplication();
        clsLocalDrivingLicenseApplication _LDLA = new clsLocalDrivingLicenseApplication();
        clsApplicationType _ApplicationType;
        public frmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _LoadData();
        }

        private void _FillLicenseClassesInComboBox()
        {
            foreach (DataRow row in clsLicenseClass.GetAllLicenseClasses().Rows)
            {
                cbLicenseClasses.Items.Add(row[0].ToString());
            }
        }

        private void _LoadData()
        {
            _FillLicenseClassesInComboBox();
            cbLicenseClasses.SelectedIndex = 2;
            lblCurrentUser.Text = GlobalSettings.CurrentUser.UserName;
            lblCurrentDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);
            lblApplicationFees.Text = _ApplicationType.ApplicationFees.ToString("00");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _PersonID = ctrlPersonCardWithFilter1.GetPersonID();
            if (_PersonID == -1)
            {
                MessageBox.Show("Please select a person to become a user.", "Select a person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                btnSave.Enabled = true;
                tcNewLocalLicense.SelectedIndex = 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.Find(cbLicenseClasses.Text).LicenseClassID;

            if (clsLocalDrivingLicenseApplication.IsPersonHasActiveApplication(_PersonID, LicenseClassID))
            {
                MessageBox.Show("This Person already has an active application for the selected license class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            if (clsLicense.IsPersonHasLicense(LicenseClassID, _PersonID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
           

            _Application.ApplicantPersonID = _PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = _ApplicationTypeID;
            _Application.ApplicationStatus = 1;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = _ApplicationType.ApplicationFees;
            _Application.CreatedByUserID = GlobalSettings.CurrentUser.UserID;

            if (!_Application.Save())
            {
                MessageBox.Show("Error : Application was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LDLA.ApplicationID = _Application.ApplicationID;
            _LDLA.LicenseClassID = LicenseClassID;

            if (!_LDLA.Save())
            {
                MessageBox.Show("Error : Local License Driving Application was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnSave.Enabled = false;
            cbLicenseClasses.Enabled = false;
            tpPersonalInfo.Enabled = false;
            MessageBox.Show("Data Saved Successfully..", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
