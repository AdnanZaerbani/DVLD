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
    public partial class frmListDrivers : Form
    {
        public frmListDrivers()
        {
            InitializeComponent();
        }
        DataTable _dtDriver;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _dtDriver = clsDriver.GetAllDriver();
            dgvAllDriver.DataSource = _dtDriver;
            lblCountRecords.Text = dgvAllDriver.RowCount.ToString();
            cbFilterBy.SelectedItem = "None";
        }

        private void _RefreshList()
        {
            _dtDriver = clsDriver.GetAllDriver();
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
                    dgvAllDriver.Sort(dgvAllDriver.Columns["Driver ID"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 2)
                    dgvAllDriver.Sort(dgvAllDriver.Columns["Person ID"], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 3)
                    dgvAllDriver.Sort(dgvAllDriver.Columns["National No."], ListSortDirection.Ascending);
                else if (cbFilterBy.SelectedIndex == 4)
                    dgvAllDriver.Sort(dgvAllDriver.Columns["Full Name"], ListSortDirection.Ascending);
                
                txtbFilter.Visible = true;
            }
        }

        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = _dtDriver.DefaultView;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: 
                    if (int.TryParse(txtbFilter.Text, out int LDLAppID))
                        dv.RowFilter = $"[Driver ID] = {LDLAppID}";
                    else
                        dv.RowFilter = "";
                    break;

                case 2: 
                    if (int.TryParse(txtbFilter.Text, out int PersoID))
                        dv.RowFilter = $"[Person ID] = {PersoID}";
                    else
                        dv.RowFilter = "";
                    break;

                case 3: 
                    dv.RowFilter = $"[National No.] LIKE '%{txtbFilter.Text}%'";
                    break;

                case 4: 
                    dv.RowFilter = $"[Full Name] LIKE '%{txtbFilter.Text}%'";
                    break;

                default:
                    dv.RowFilter = "";
                    break;
            }

            dgvAllDriver.DataSource = dv;
        }

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }


    }
}
