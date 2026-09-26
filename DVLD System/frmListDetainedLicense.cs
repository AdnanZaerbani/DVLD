using DVLD_System___BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class frmListDetainedLicense : Form
    {
        DataTable _dtDetain;
        int _LicenseID;
        clsLicense _License = new clsLicense();
        clsPerson _Person = new clsPerson();
        clsApplication _App = new clsApplication();
        public frmListDetainedLicense()
        {
            InitializeComponent();
            _dtDetain = clsDetainedLicense.GetAllDetained();
            dgvAllDetained.DataSource = _dtDetain;
        }

        private void _RefreshList()
        {
            dgvAllDetained.DataSource = clsDetainedLicense.GetAllDetained();
            lblCountRecords.Text = dgvAllDetained.RowCount.ToString();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshList();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
            _RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDetainedLicense_Load(object sender, EventArgs e)
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
                    dgvAllDetained.Sort(dgvAllDetained.Columns["D.ID"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 2)
                    dgvAllDetained.Sort(dgvAllDetained.Columns["Is Released"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 3)
                    dgvAllDetained.Sort(dgvAllDetained.Columns["N.No."], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 4)
                    dgvAllDetained.Sort(dgvAllDetained.Columns["Full Name"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 5)
                    dgvAllDetained.Sort(dgvAllDetained.Columns["Release App.ID"], ListSortDirection.Ascending);

                txtbFilter.Visible = true;
            }
        }

        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = _dtDetain.DefaultView;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: 
                    if (int.TryParse(txtbFilter.Text, out int DetainID))
                        dv.RowFilter = $"[D.ID] = {DetainID}";
                    else
                        dv.RowFilter = "";
                    break;

                case 2:
                    if (int.TryParse(txtbFilter.Text, out int IsReleased))
                        dv.RowFilter = $"[Is Released] = {IsReleased}";
                    else
                        dv.RowFilter = "";
                    break;

                case 3: 
                    dv.RowFilter = $"[N.No.] LIKE '%{txtbFilter.Text}%'";
                    break;

                case 4: 
                    dv.RowFilter = $"[Full Name] LIKE '%{txtbFilter.Text}%'";
                    break;

                case 5:
                    if (int.TryParse(txtbFilter.Text, out int ReleaseApplicationID))
                        dv.RowFilter = $"[Release App.ID] = {ReleaseApplicationID}";
                    else
                        dv.RowFilter = "";
                    break;

                default:
                    dv.RowFilter = "";
                    break;
            }

            dgvAllDetained.DataSource = dv;
        }

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 5)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LicenseID = Convert.ToInt32(dgvAllDetained.SelectedRows[0].Cells["L.ID"].Value);
            _License = clsLicense.FindLicense(_LicenseID);
            _Person = clsPerson.Find(_License.NationalNo);
            frmPersonDetails frmPersonDetails = new frmPersonDetails(_Person.PersonID);
            frmPersonDetails.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LicenseID = Convert.ToInt32(dgvAllDetained.SelectedRows[0].Cells["L.ID"].Value);
            _License = clsLicense.FindLicenseApplication(_LicenseID);
            _App = clsApplication.Find(_License.ApplicationID);
            frmLicenseInfo frmLicenseInfo1 = new frmLicenseInfo(_App.ApplicationID);
            frmLicenseInfo1.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LicenseID = Convert.ToInt32(dgvAllDetained.SelectedRows[0].Cells["L.ID"].Value);
            _License = clsLicense.FindLicense(_LicenseID);
            _Person = clsPerson.Find(_License.NationalNo);
            frmLicenseHistory frmLicenseHistory = new frmLicenseHistory(_Person.PersonID);
            frmLicenseHistory.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LicenseID = Convert.ToInt32(dgvAllDetained.SelectedRows[0].Cells["L.ID"].Value);
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense(_LicenseID);
            frmReleaseDetainedLicense.ShowDialog();
            _RefreshList();
        }

        private void cmsDetails_Opening(object sender, CancelEventArgs e)
        {
            if (dgvAllDetained.SelectedRows.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            int IsReleased = Convert.ToInt32(dgvAllDetained.SelectedRows[0].Cells["Is Released"].Value);

            if (IsReleased == 0)
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = true;
                return;
            }

            releaseDetainedLicenseToolStripMenuItem.Enabled = false;

        }
    }
}
