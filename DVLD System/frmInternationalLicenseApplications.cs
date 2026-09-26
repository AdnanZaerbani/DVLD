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
    public partial class frmInternationalLicenseApplications : Form
    {
        DataTable _dtIntLicense;
        int _LicenseID;
        int _AppID;
        clsApplication _App = new clsApplication();
        clsLicense _License = new clsLicense();
        clsPerson _Person = new clsPerson();    
        public frmInternationalLicenseApplications()
        {
            InitializeComponent();
            _dtIntLicense = clsInternationalLicense.GetAllInternationalLicense();
            dgvAllIntLicense.DataSource = _dtIntLicense;
        }
        
        private void _RefreshList()
        {
            dgvAllIntLicense.DataSource = clsInternationalLicense.GetAllInternationalLicense();
            lblCountRecords.Text = dgvAllIntLicense.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewIntLicenseApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
            _RefreshList();
        }

        private void frmInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreshList();
            cbFilterBy.SelectedItem = "None";
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtbFilter.Visible = false;
                _RefreshList();
            }
            else
            {
                if (cbFilterBy.SelectedIndex == 1)
                    dgvAllIntLicense.Sort(dgvAllIntLicense.Columns["Int.License ID"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 2)
                    dgvAllIntLicense.Sort(dgvAllIntLicense.Columns["Application ID"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 3)
                    dgvAllIntLicense.Sort(dgvAllIntLicense.Columns["Driver ID"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 4)
                    dgvAllIntLicense.Sort(dgvAllIntLicense.Columns["L.License ID"], ListSortDirection.Ascending);

                txtbFilter.Visible = true;
            }
        }

        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = _dtIntLicense.DefaultView;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    if (int.TryParse(txtbFilter.Text, out int IntLicenseID))
                        dv.RowFilter = $"[Int.License ID] = {IntLicenseID}";
                    else
                        dv.RowFilter = "";
                    break;

                case 2:
                    if (int.TryParse(txtbFilter.Text, out int ApplicationID))
                        dv.RowFilter = $"[Application ID] = {ApplicationID}";
                    else
                        dv.RowFilter = "";
                    break;

                case 3:
                    if (int.TryParse(txtbFilter.Text, out int DriverID))
                        dv.RowFilter = $"[Driver ID] = {DriverID}";
                    else
                        dv.RowFilter = "";
                    break;

                case 4:
                    if (int.TryParse(txtbFilter.Text, out int LLicenseID))
                        dv.RowFilter = $"[L.License ID] = {LLicenseID}";
                    else
                        dv.RowFilter = "";
                    break;

                default:
                    dv.RowFilter = "";
                    break;
            }

            dgvAllIntLicense.DataSource = dv;
        }

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LicenseID = Convert.ToInt32(dgvAllIntLicense.SelectedRows[0].Cells["L.License ID"].Value);
            _License = clsLicense.FindLicense(_LicenseID);
            _Person = clsPerson.Find(_License.NationalNo);
            frmPersonDetails frmPersonDetails = new frmPersonDetails(_Person.PersonID);
            frmPersonDetails.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AppID = Convert.ToInt32(dgvAllIntLicense.SelectedRows[0].Cells["Application ID"].Value);
            _App = clsApplication.Find(_AppID);
            frmLicenseInfo frmLicenseInfo1 = new frmLicenseInfo(_App.ApplicationID - 1);
            frmLicenseInfo1.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LicenseID = Convert.ToInt32(dgvAllIntLicense.SelectedRows[0].Cells["L.License ID"].Value);
            _License = clsLicense.FindLicense(_LicenseID);
            _Person = clsPerson.Find(_License.NationalNo);
            frmLicenseHistory frmLicenseHistory = new frmLicenseHistory(_Person.PersonID);
            frmLicenseHistory.ShowDialog();
        }
    }
}
