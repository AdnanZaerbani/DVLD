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
    public partial class frmManageApplicationTypes : Form
    {
        DataTable _dtApplicationTypes;
        int _ApplicationTypeID = -1;
        public frmManageApplicationTypes()
        {
            InitializeComponent();
            _dtApplicationTypes = clsApplicationType.GetAllApplicationType();
            dgvAllApplicationTypes.DataSource = _dtApplicationTypes;
        }

        private void _RefreshApplicationTypeList()
        {
            dgvAllApplicationTypes.DataSource = clsApplicationType.GetAllApplicationType();
            lblCountRecords.Text = dgvAllApplicationTypes.RowCount.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypeList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ApplicationTypeID = Convert.ToInt32(dgvAllApplicationTypes.SelectedRows[0].Cells["ID"].Value);
            frmUpdateApplicationType frmUpdateApplicationType = new frmUpdateApplicationType(_ApplicationTypeID);
            frmUpdateApplicationType.ShowDialog();
            _RefreshApplicationTypeList();
        }
    }
}
