using DVLD_System.Properties;
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
    public partial class ctrlDILInfo : UserControl
    {
        public ctrlDILInfo()
        {
            InitializeComponent();
        }
        int _IntLicenseID;
        int _PersonID;
        clsInternationalLicense _IntLicense = new clsInternationalLicense();
        clsPerson _Person = new clsPerson();
        public ctrlDILInfo(int IntLicenseID, int PersonID)
        {
            InitializeComponent();
            _IntLicenseID = IntLicenseID;
            _PersonID = PersonID;
        }

        private void _LoadData(int IntLicenseID, int PersonID)
        {
            _IntLicenseID = IntLicenseID;
            _PersonID = PersonID;
            _Person = clsPerson.Find(_PersonID);
            _IntLicense = clsInternationalLicense.Find(_IntLicenseID);
            lblFullName.Text = string.Join(" ", new[] { _Person.FirstName, _Person.SecondName, _Person.ThirdName, _Person.LastName }.Where(x => !string.IsNullOrWhiteSpace(x)));
            lblIntLicenseID.Text = _IntLicenseID.ToString();
            lblLicenseID.Text = _IntLicense.IssuedUsingLocalLicenseID.ToString();
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

            lblIssueDate.Text = _IntLicense.IssueDate.ToString("dd/MMM/yyyy");

            lblApplicationID.Text = _IntLicense.ApplicationID.ToString();
            lblIsActive.Text = _IntLicense.IsActive.ToString();
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString("dd/MMM/yyyy");
            lblDiverID.Text = _IntLicense.DriverID.ToString();
            lblExpirationDate.Text = _IntLicense.ExpirationDate.ToString("dd/MMM/yyyy");
        }

        public void LoadData(int IntLicenseID, int PersonID)
        {
            _LoadData(IntLicenseID, PersonID);
        }
    }
}
