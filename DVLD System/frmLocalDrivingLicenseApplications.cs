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
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        DataTable _dtLDLA;
        clsApplication _Application = new clsApplication();
        byte _ChangeStatus;
        int _ApplicationID;
        int _DLAppID;
        clsPerson _Person = new clsPerson();
        string _NationalNo;

        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _dtLDLA = clsLocalDrivingLicenseApplication.GetAllLDLA();
            dgvAllLDLA.DataSource = _dtLDLA;
            dgvAllLDLA.Columns["ApplicationID"].Visible = false;
        }

        private void _RefreshLDLAList()
        {
            dgvAllLDLA.DataSource = clsLocalDrivingLicenseApplication.GetAllLDLA();
            lblCountRecords.Text = dgvAllLDLA.RowCount.ToString();
        }

        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frmNew = new frmNewLocalDrivingLicenseApplication();
            frmNew.ShowDialog();
            _RefreshLDLAList();
        }

        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreshLDLAList();
            cbFilterBy.SelectedItem = "None";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtbFilter.Visible = false;
                _RefreshLDLAList();
            }
            else
            {
                if (cbFilterBy.SelectedIndex == 1)
                    dgvAllLDLA.Sort(dgvAllLDLA.Columns["L.D.L.AppID"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 2)
                    dgvAllLDLA.Sort(dgvAllLDLA.Columns["National No."], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 3)
                    dgvAllLDLA.Sort(dgvAllLDLA.Columns["Full Name"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 4)
                    dgvAllLDLA.Sort(dgvAllLDLA.Columns["Status"], ListSortDirection.Ascending);

                txtbFilter.Visible = true;
            }
        }

        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = _dtLDLA.DefaultView;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: 
                    if (int.TryParse(txtbFilter.Text, out int LDLAppID))
                        dv.RowFilter = $"[L.D.L.AppID] = {LDLAppID}";
                    else
                        dv.RowFilter = "";
                    break;

                case 2: 
                    dv.RowFilter = $"[National No.] LIKE '%{txtbFilter.Text}%'";
                    break;

                case 3: 
                    dv.RowFilter = $"[Full Name] LIKE '%{txtbFilter.Text}%'";
                    break;

                case 4: 
                    dv.RowFilter = $"[Status] LIKE '%{txtbFilter.Text}%'";
                    break;

                default:
                    dv.RowFilter = "";
                    break;
            }

            dgvAllLDLA.DataSource = dv;
        }

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChangeStatus = 2;
            _ApplicationID = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["ApplicationID"].Value);
            if (MessageBox.Show("Are you sure you want to cancel this application has id = " + dgvAllLDLA.CurrentRow.Cells[0].Value, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                _Application.UpdateApplicationStatus(_ApplicationID, _ChangeStatus);
                _RefreshLDLAList();
            }
            
        }

        private void sheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DLAppID = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["L.D.L.AppID"].Value);
            _ApplicationID = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["ApplicationID"].Value);
            ctrlTestAppointment ctrlTestAppointment = new ctrlTestAppointment(_DLAppID, _ApplicationID);
            frmVisionTestAppointments frmVisionTestAppointments = new frmVisionTestAppointments(_DLAppID, _ApplicationID);
            frmVisionTestAppointments.ShowDialog();
            _RefreshLDLAList();
        }

        private void sheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DLAppID = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["L.D.L.AppID"].Value);
            _ApplicationID = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["ApplicationID"].Value);
            ctrlTestAppointment ctrlTestAppointment = new ctrlTestAppointment(_DLAppID, _ApplicationID);
            frmWrittenTestAppointments frmWrittenTestAppointments = new frmWrittenTestAppointments(_DLAppID, _ApplicationID);
            frmWrittenTestAppointments.ShowDialog();
            _RefreshLDLAList();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DLAppID = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["L.D.L.AppID"].Value);
            _ApplicationID = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["ApplicationID"].Value);
            ctrlTestAppointment ctrlTestAppointment = new ctrlTestAppointment(_DLAppID, _ApplicationID);
            frmStreetTestAppointments frmStreetTestAppointments = new frmStreetTestAppointments(_DLAppID, _ApplicationID);
            frmStreetTestAppointments.ShowDialog();
            _RefreshLDLAList();
        }

        private void cmsDetails_Opening(object sender, CancelEventArgs e)
        {
            if (dgvAllLDLA.SelectedRows.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            int passedTests = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["Passed Tests"].Value);

            string status = dgvAllLDLA.SelectedRows[0].Cells["Status"].Value.ToString();

            
            if (status == "Cancelled")
            {
                showDetailsToolStripMenuItem.Enabled = true;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = true;
                phoneCallToolStripMenuItem.Enabled = false;
                sechduleTestsToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;

                return;
            }

            if (passedTests == 3 && status == "Completed")
            {
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = true;
                phoneCallToolStripMenuItem.Enabled = false;

                sechduleTestsToolStripMenuItem.Enabled = false;

                sheduleVisionTestToolStripMenuItem.Enabled = false;
                sheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;

                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;

                showLicenseToolStripMenuItem.Enabled = true;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = true;

                return;
            }
            showDetailsToolStripMenuItem.Enabled = true;
            editToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
            phoneCallToolStripMenuItem.Enabled = true;
            sechduleTestsToolStripMenuItem.Enabled = true;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
            sheduleVisionTestToolStripMenuItem.Enabled = false;
            sheduleWrittenTestToolStripMenuItem.Enabled = false;
            scheduleStreetTestToolStripMenuItem.Enabled = false;



            switch (passedTests)
            {
                case 0:
                    sheduleVisionTestToolStripMenuItem.Enabled = true;
                    break;

                case 1:
                    sheduleWrittenTestToolStripMenuItem.Enabled = true;
                    break;

                case 2:
                    scheduleStreetTestToolStripMenuItem.Enabled = true;
                    break;

                case 3:
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                    break;
            }
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DLAppID = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["L.D.L.AppID"].Value);
            _ApplicationID = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["ApplicationID"].Value);
            ctrlTestAppointment ctrlTestAppointment = new ctrlTestAppointment(_DLAppID, _ApplicationID);
            frmIssueDriverLicenseForTheFirstTime frmIssueDriverLicenseForTheFirstTime = new frmIssueDriverLicenseForTheFirstTime(_DLAppID, _ApplicationID); 
            frmIssueDriverLicenseForTheFirstTime.ShowDialog();
            _RefreshLDLAList();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ApplicationID = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["ApplicationID"].Value);
            frmLicenseInfo frmLicenseInfo1 = new frmLicenseInfo(_ApplicationID);
            frmLicenseInfo1.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _NationalNo = (dgvAllLDLA.SelectedRows[0].Cells["National No."].Value).ToString();
            _Person = clsPerson.Find(_NationalNo);
            frmLicenseHistory frmLicenseHistory = new frmLicenseHistory(_Person.PersonID);
            frmLicenseHistory.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DLAppID = Convert.ToInt32(dgvAllLDLA.SelectedRows[0].Cells["L.D.L.AppID"].Value);
            if (MessageBox.Show("Are you sure you want to delete this application? ", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplication.DeleteApplication((int)dgvAllLDLA.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Application deleted successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    _RefreshLDLAList();
                }
                else
                {
                    MessageBox.Show("Application is not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _NationalNo = (dgvAllLDLA.SelectedRows[0].Cells["National No."].Value).ToString();
            _Person = clsPerson.Find(_NationalNo);
            frmPersonDetails frmPersonDetails = new frmPersonDetails(_Person.PersonID);
            frmPersonDetails.ShowDialog();
        }
    }
}
