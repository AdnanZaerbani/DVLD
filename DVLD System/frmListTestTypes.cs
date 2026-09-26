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
    public partial class frmListTestTypes : Form
    {
        DataTable _dtTestTypes;
        int _TestTypeID = -1;
        public frmListTestTypes()
        {
            InitializeComponent();
            _dtTestTypes = clsTestType.GetAllTestType();
            dgvAllTestTypes.DataSource = _dtTestTypes;
        }

        private void _RefreshTestTypeList()
        {
            dgvAllTestTypes.DataSource = clsTestType.GetAllTestType();
            lblCountRecords.Text = dgvAllTestTypes.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypeList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _TestTypeID = Convert.ToInt32(dgvAllTestTypes.SelectedRows[0].Cells["ID"].Value);
            frmUpdateTestType frmUpdateTestType = new frmUpdateTestType(_TestTypeID);
            frmUpdateTestType.ShowDialog();
            _RefreshTestTypeList();
        }
    }
}
