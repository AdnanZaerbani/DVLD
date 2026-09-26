using DVLD_System.Properties;
using DVLD_System___BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class ctrlPersonCard : UserControl
    {
        int _PersonID;
        clsPerson _Person;

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public ctrlPersonCard(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void _LoadPersonData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }


            lblPersonID.Text = _PersonID.ToString();
            lblName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
            lblNationalNo.Text = _Person.NationalNo;
            
            if (_Person.Gender == 0)
            {
                lblGender.Text = "Male";
                pbGender.Image = Resources.Man_32;
            }

            if (_Person.Gender == 1)
            {
                lblGender.Text = "Female";
                pbGender.Image = Resources.Woman_32;
            }

            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblPhone.Text = _Person.Phone;
            lblAddress.Text = _Person.Address;
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                string peopleFolder = Path.Combine(
                    Application.StartupPath,
                    "People-Images"
                );

                string[] files = Directory.GetFiles(
                    peopleFolder,
                    _Person.ImagePath + ".*"
                );

                if (files.Length > 0)
                {
                    pbImage.ImageLocation = files[0];
                }
            }
            else
            {
                if (lblGender.Text == "Male")
                {
                    pbImage.Image = Resources.Male_512;
                }

                if (lblGender.Text == "Female")
                {
                    pbImage.Image = Resources.Female_512;
                }
            }
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ctrlAddEditPersonCard ctrlPersonCard = new ctrlAddEditPersonCard(_PersonID);
            frmAddEditPerson frmAddNewPerson = new frmAddEditPerson(_PersonID);
            frmAddNewPerson.ShowDialog();
            this.FindForm()?.Close();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;
            _LoadPersonData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }
    }
}
