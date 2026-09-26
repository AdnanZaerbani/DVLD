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
    public partial class ctrlTestAppointment : UserControl
    {
        int _DLAppID = 0;
        clsLocalDrivingLicenseApplication _LDLApp;

        int _AppID = 0;
        clsApplication _App;
        public ctrlTestAppointment()
        {
            InitializeComponent();
        }

        public ctrlTestAppointment(int DLAppID, int AppID)
        {
            InitializeComponent();
            _DLAppID = DLAppID;
            _AppID = AppID;
        }

        private void _LoadLDAppData()
        {
            _LDLApp = clsLocalDrivingLicenseApplication.Find(_DLAppID);

            if (_LDLApp == null)
            {
                MessageBox.Show("This form will be closed because No Driving License Application with ID = " + _DLAppID, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            lblDLAppID.Text = _DLAppID.ToString();
            lblAppliedForLicense.Text = _LDLApp.ClassName;
            lblPassedTest.Text = _LDLApp.PassedTestCount.ToString() + "/3";
        }

        private void _LoadAppData()
        {
            _App = clsApplication.Find(_AppID);

            if (_App == null)
            {
                MessageBox.Show("This form will be closed because No Application with ID = " + _AppID, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            lblID.Text = _AppID.ToString();

            if (_App.ApplicationStatus == 1)
            {
                lblStatus.Text = "New";
            }
            if (_App.ApplicationStatus == 2)
            {
                lblStatus.Text = "Canceled";
            }
            if (_App.ApplicationStatus == 3)
            {
                lblStatus.Text = "Completed";
            }

            lblFees.Text = _App.AppFees.ToString("00");
            lblType.Text = _App.AppTitle.ToString();
            lblApplicant.Text = _App.FullName;
            lblDate.Text = _App.ApplicationDate.ToString("d/MMM/yyyy");
            lblStatusDate.Text = _App.LastStatusDate.ToString("d/MMM/yyyy");
            lblCreatedBy.Text = _App.UserName.ToString();
        }

        public void LoadInfo(int DLAppID, int AppID)
        {
            _DLAppID = DLAppID;
            _AppID = AppID;
            _LoadLDAppData();
            _LoadAppData();
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frmPersonDetails = new frmPersonDetails(_App.ApplicantPersonID);
            frmPersonDetails.ShowDialog();
        }
    }
}
