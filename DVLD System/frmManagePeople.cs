using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_System___BusinessLayer;

namespace DVLD_System
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
            _dtPerson = clsPerson.GetAllPeople();
            dgvAllPepole.DataSource = _dtPerson;
        }

        int _PersonID = -1;
        DataTable _dtPerson;

        private void _RefreshPeopleList()
        {
            dgvAllPepole.DataSource = clsPerson.GetAllPeople();
            lblCountRecords.Text = dgvAllPepole.RowCount.ToString();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
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
                _RefreshPeopleList();
            }
            else
            {
                if (cbFilterBy.SelectedIndex == 1)
                    dgvAllPepole.Sort(dgvAllPepole.Columns["Person ID"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 2)
                    dgvAllPepole.Sort(dgvAllPepole.Columns["National No."], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 3)
                    dgvAllPepole.Sort(dgvAllPepole.Columns["First Name"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 4)
                    dgvAllPepole.Sort(dgvAllPepole.Columns["Second Name"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 5)
                    dgvAllPepole.Sort(dgvAllPepole.Columns["Third Name"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 6)
                    dgvAllPepole.Sort(dgvAllPepole.Columns["Last Name"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 7)
                    dgvAllPepole.Sort(dgvAllPepole.Columns["Nationality"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 8)
                    dgvAllPepole.Sort(dgvAllPepole.Columns["Gender"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 9)
                    dgvAllPepole.Sort(dgvAllPepole.Columns["Phone"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 10)
                    dgvAllPepole.Sort(dgvAllPepole.Columns["Email"], ListSortDirection.Ascending);

                txtbFilter.Visible = true;
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            _PersonID = -1;
            ctrlAddEditPersonCard ctrlPersonCard = new ctrlAddEditPersonCard(-1);
            frmAddEditPerson frmAddNewPerson = new frmAddEditPerson();
            frmAddNewPerson.ShowDialog();
            _RefreshPeopleList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _PersonID = -1;
            ctrlAddEditPersonCard ctrlPersonCard = new ctrlAddEditPersonCard(-1);
            frmAddEditPerson frmAddNewPerson = new frmAddEditPerson();
            frmAddNewPerson.ShowDialog();
            _RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _PersonID = Convert.ToInt32(dgvAllPepole.SelectedRows[0].Cells["Person ID"].Value);
            ctrlAddEditPersonCard ctrlPersonCard = new ctrlAddEditPersonCard(_PersonID);
            frmAddEditPerson frmAddNewPerson = new frmAddEditPerson(_PersonID);
            frmAddNewPerson.ShowDialog();
            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvAllPepole.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel ,MessageBoxIcon.Question ,MessageBoxDefaultButton.Button1) ==DialogResult.OK) 
            {
                if (clsPerson.DeletePerson((int)dgvAllPepole.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person deleted successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Person is not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = _dtPerson.DefaultView;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: // Person ID
                    if (int.TryParse(txtbFilter.Text, out int PersonID))
                        dv.RowFilter = $"[Person ID] = {PersonID}";
                    else
                        dv.RowFilter = "";
                    break;

                case 2: // National No.
                    dv.RowFilter = $"[National No.] LIKE '%{txtbFilter.Text}%'";
                    break;

                case 3: // First Name
                    dv.RowFilter = $"[First Name] LIKE '%{txtbFilter.Text}%'";
                    break;

                case 4: // Second Name
                    dv.RowFilter = $"[Second Name] LIKE '%{txtbFilter.Text}%'";
                    break;

                case 5: // Third Name
                    dv.RowFilter = $"[Third Name] LIKE '%{txtbFilter.Text}%'";
                    break;

                case 6: // Last Name
                    dv.RowFilter = $"[Last Name] LIKE '%{txtbFilter.Text}%'";
                    break;

                case 7: // Nationality
                    dv.RowFilter = $"Nationality LIKE '%{txtbFilter.Text}%'";
                    break;

                case 8: // Gender
                    dv.RowFilter = $"Gender LIKE '%{txtbFilter.Text}%'";
                    break;

                case 9: // Phone
                    dv.RowFilter = $"Phone LIKE '%{txtbFilter.Text}%'";
                    break;

                case 10: // Email
                    dv.RowFilter = $"Email LIKE '%{txtbFilter.Text}%'";
                    break;

                default:
                    dv.RowFilter = "";
                    break;
            }

            dgvAllPepole.DataSource = dv;
        }

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 9)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _PersonID = Convert.ToInt32(dgvAllPepole.SelectedRows[0].Cells["Person ID"].Value);
            ctrlPersonCard ctrlPersonCardInfo = new ctrlPersonCard(_PersonID);
            frmPersonDetails frmPersonDetails = new frmPersonDetails(_PersonID);
            frmPersonDetails.ShowDialog();
            _RefreshPeopleList();
        }
    }
}
