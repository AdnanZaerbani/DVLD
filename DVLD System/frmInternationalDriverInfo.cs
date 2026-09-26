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
    public partial class frmInternationalDriverInfo : Form
    {
        public frmInternationalDriverInfo()
        {
            InitializeComponent();
        }

        public frmInternationalDriverInfo(int IntLicenseID, int PersonID)
        {
            InitializeComponent();
            ctrlDILInfo1.LoadData(IntLicenseID, PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
