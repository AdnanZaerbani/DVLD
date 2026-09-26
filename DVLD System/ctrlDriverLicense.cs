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
    public partial class ctrlDriverLicense : UserControl
    {
        DataTable _dtIntLicense;
        DataTable _dtLicense;
        int _PersonID;
        int _AppID;
        clsApplication _App = new clsApplication();
        public ctrlDriverLicense()
        {
            InitializeComponent();
        }

        public void LoadData(int PersonID)
        {
            _PersonID = PersonID;

            _dtLicense = clsLicense.GetAllLicense(_PersonID);
            dgvAllLicense.DataSource = _dtLicense;
            lblCountRecordsLocal.Text = dgvAllLicense.RowCount.ToString();

            _dtIntLicense = clsInternationalLicense.GetInternationalLicense(_PersonID);
            dgvAllIntLicense.DataSource = _dtIntLicense;
            lblCounterRecordsInternational.Text = dgvAllIntLicense.RowCount.ToString();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AppID = Convert.ToInt32(dgvAllLicense.SelectedRows[0].Cells["Application ID"].Value);
            _App = clsApplication.Find(_AppID);
            frmLicenseInfo frmLicenseInfo1 = new frmLicenseInfo(_App.ApplicationID);
            frmLicenseInfo1.ShowDialog();
        }
    }
}
