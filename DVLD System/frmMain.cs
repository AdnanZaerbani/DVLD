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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void MSIPeople_Click(object sender, EventArgs e)
        {
            frmManagePeople frmManagePeople = new frmManagePeople();
            frmManagePeople.ShowDialog();
        }

        private void MSIDrivers_Click(object sender, EventArgs e)
        {
            frmListDrivers frmListDrivers = new frmListDrivers();
            frmListDrivers.ShowDialog();
        }

        private void MSIUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frmUserDetails = new frmUserDetails(GlobalSettings.CurrentUser.PersonID, GlobalSettings.CurrentUser.UserID);
            frmUserDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(GlobalSettings.CurrentUser.PersonID, GlobalSettings.CurrentUser.UserID);
            frmChangePassword.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frmManageApplicationTypes = new frmManageApplicationTypes();
            frmManageApplicationTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frmListTestTypes = new frmListTestTypes();
            frmListTestTypes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frmNewLocalDrivingLicenseApplication = new frmNewLocalDrivingLicenseApplication();
            frmNewLocalDrivingLicenseApplication.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications frm = new frmLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frmNewInternationalLicenseApplication = new frmNewInternationalLicenseApplication();
            frmNewInternationalLicenseApplication.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplications frm = new frmInternationalLicenseApplications();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicense frmRenewLocalLicense = new frmRenewLocalLicense();
            frmRenewLocalLicense.ShowDialog();
        }

        private void replacementForLostOtDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementForDamagedLicense frm = new frmReplacementForDamagedLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDetainLicense = new frmDetainLicense();
            frmDetainLicense.ShowDialog();
        }

        private void releaseDetainedLicensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicense frmListDetainedLicense = new frmListDetainedLicense();   
            frmListDetainedLicense.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications frm = new frmLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }
    }
}
