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
    public partial class frmStreetTestAppointments : Form
    {
        public frmStreetTestAppointments()
        {
            InitializeComponent();
        }
        int _Trial;
        int _DLAppID;
        int _AppID;
        int _TestAppID;
        DataTable _dtAppointment;
        public frmStreetTestAppointments(int DLAppID, int AppID)
        {
            InitializeComponent();
            _DLAppID = DLAppID;
            _AppID = AppID;
            ctrlTestAppointment1.LoadInfo(DLAppID, AppID);
        }

        private void _RefreshList()
        {
            _dtAppointment = clsTestAppointment.GetAllTestAppointment(_DLAppID, 3);
            dgvAllTestAppointments.DataSource = _dtAppointment;
            lblCountRecords.Text = dgvAllTestAppointments.RowCount.ToString();
            _Trial = Convert.ToInt32(lblCountRecords.Text) + 1;
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            if (clsTest.IsPersonPassed(_DLAppID, 3))
            {
                MessageBox.Show("This Person already passed this test before, you can only retake faild test", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool HasActiveAppoitment = false;

            foreach (DataRow row in _dtAppointment.Rows)
            {
                if (Convert.ToInt16(row["Is Locked"]) == 0)
                {
                    HasActiveAppoitment = true;
                    break;
                }
            }

            if (HasActiveAppoitment)
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frmScheduleTest = new frmScheduleTest(_DLAppID, _AppID, _Trial, 3);
            frmScheduleTest.ShowDialog();
            _RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStreetTestAppointments_Load(object sender, EventArgs e)
        {
            _RefreshList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            short TestTimeHasEnded;
            TestTimeHasEnded = Convert.ToInt16(dgvAllTestAppointments.SelectedRows[0].Cells["Is Locked"].Value);
            if (TestTimeHasEnded == 1)
            {
                MessageBox.Show("The test time has ended", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _TestAppID = Convert.ToInt32(dgvAllTestAppointments.SelectedRows[0].Cells["Appointment ID"].Value);
            frmScheduleTest frmScheduleTest = new frmScheduleTest(_DLAppID, _AppID, _Trial, _TestAppID);
            frmScheduleTest.ShowDialog();
            _RefreshList();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _TestAppID = Convert.ToInt32(dgvAllTestAppointments.SelectedRows[0].Cells["Appointment ID"].Value);
            frmTakeTest frmTakeTest = new frmTakeTest(_DLAppID, _AppID, _TestAppID, _Trial);
            frmTakeTest.ShowDialog();
            _RefreshList();
            ctrlTestAppointment1.LoadInfo(_DLAppID, _AppID);
        }

        private void dgvAllTestAppointments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvAllTestAppointments.Rows.Count == 0)
                {
                    dgvAllTestAppointments.ContextMenuStrip = null;
                }
                else
                {
                    dgvAllTestAppointments.ContextMenuStrip = cmsDetails;
                }
            }
        }
    }
}
