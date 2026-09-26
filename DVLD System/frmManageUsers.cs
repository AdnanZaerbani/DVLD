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
    public partial class frmManageUsers : Form
    {
        DataTable _dtUsers;
        int _UserID = -1;
        int _PersonID = -1;
        public frmManageUsers()
        {
            InitializeComponent();
            _dtUsers = clsUser.GetAllUsers();
            dgvAllUsers.DataSource = _dtUsers;
        }

        private void _RefreshUsersList()
        {
            dgvAllUsers.DataSource = clsUser.GetAllUsers();
            lblCountRecords.Text = dgvAllUsers.RowCount.ToString();
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
            cbFilterBy.SelectedItem = "None";
            cbIsActive.SelectedItem = "All";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddNewUser = new frmAddEditUser();
            frmAddNewUser.ShowDialog();
            _RefreshUsersList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtbFilter.Visible = false;
                cbIsActive.Visible = false;
                _RefreshUsersList();
            }
            else
            {
                if (cbFilterBy.SelectedIndex == 1)
                    dgvAllUsers.Sort(dgvAllUsers.Columns["UserID"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 2)
                    dgvAllUsers.Sort(dgvAllUsers.Columns["UserName"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 3)
                    dgvAllUsers.Sort(dgvAllUsers.Columns["PersonID"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 4)
                    dgvAllUsers.Sort(dgvAllUsers.Columns["FullName"], ListSortDirection.Ascending);

                txtbFilter.Visible = true;
                cbIsActive.Visible = false;
                _RefreshUsersList();
            }

            if (cbFilterBy.SelectedIndex == 5)
            {
                cbIsActive.Visible = true;
                txtbFilter.Visible = false;
                _RefreshUsersList();
            }
        }

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 3)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = _dtUsers.DefaultView;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: // User ID

                    if (int.TryParse(txtbFilter.Text, out int UserID))
                        dv.RowFilter = $"[UserID] = {UserID}";
                    else
                        dv.RowFilter = "";

                    break;

                case 2: // User Name

                    dv.RowFilter =
                        $"[UserName] LIKE '%{txtbFilter.Text.Replace("'", "''")}%'";

                    break;

                case 3: // Person ID

                    if (int.TryParse(txtbFilter.Text, out int PersonID))
                        dv.RowFilter = $"[PersonID] = {PersonID}";
                    else
                        dv.RowFilter = "";

                    break;

                case 4: // Full Name

                    dv.RowFilter =
                        $"[FullName] LIKE '%{txtbFilter.Text.Replace("'", "''")}%'";

                    break;

                default:

                    dv.RowFilter = "";

                    break;
            }

            dgvAllUsers.DataSource = dv;
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = _dtUsers.DefaultView;

            if (cbIsActive.SelectedIndex == 0) // All
            {
                dv.RowFilter = "";
            }
            else if (cbIsActive.SelectedIndex == 1) // Yes
            {
                dv.RowFilter = "[IsActive] = true";
            }
            else if (cbIsActive.SelectedIndex == 2) // No
            {
                dv.RowFilter = "[IsActive] = false";
            }

            dgvAllUsers.DataSource = dv;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UserID = Convert.ToInt32(dgvAllUsers.SelectedRows[0].Cells["UserID"].Value);
            _PersonID = Convert.ToInt32(dgvAllUsers.SelectedRows[0].Cells["PersonID"].Value);
            ctrlPersonCardWithFilter ctrlPersonCardWithFilter = new ctrlPersonCardWithFilter(_PersonID);
            frmAddEditUser frm = new frmAddEditUser(_UserID,_PersonID);
            frm.Text = "Update User";
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvAllUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvAllUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User has been deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("User is not deleted because due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _UserID = Convert.ToInt32(dgvAllUsers.SelectedRows[0].Cells["UserID"].Value);
            _PersonID = Convert.ToInt32(dgvAllUsers.SelectedRows[0].Cells["PersonID"].Value);
            frmChangePassword frmChangePassword = new frmChangePassword(_PersonID,_UserID);
            frmChangePassword.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddEditUser = new frmAddEditUser();
            frmAddEditUser.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UserID = Convert.ToInt32(dgvAllUsers.SelectedRows[0].Cells["UserID"].Value);
            _PersonID = Convert.ToInt32(dgvAllUsers.SelectedRows[0].Cells["PersonID"].Value);
            frmUserDetails frmUserDetails = new frmUserDetails(_PersonID, _UserID);
            frmUserDetails.ShowDialog();
        }
    }
}
