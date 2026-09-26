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
    public partial class frmUserDetails : Form
    {
        public frmUserDetails()
        {
            InitializeComponent();
        }

        public frmUserDetails(int PersonID, int UserID)
        {
            InitializeComponent();
            ctrlUserCard1.LoadDataInfo(PersonID,UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
