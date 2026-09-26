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
    public partial class frmLicenseHistory : Form
    {
        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            ctrlDriverLicense1.LoadData(PersonID);
            ctrlPersonCardWithFilter1.LoadPersonInfoByPersonID(PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
