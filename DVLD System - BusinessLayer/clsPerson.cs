using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DVLD_System___DataAccessLayer;
using System.Xml.Linq;

namespace DVLD_System___BusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public short Gender { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        public string ImagePath { set; get; }

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = -1;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            short Gender, string Phone, string Email, int NationalityCountryID, string Address, string ImagePath)

        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.Address = Address;

            Mode = enMode.Update;

        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, 
                this.Phone, this.Email, this.NationalityCountryID, this.Address, this.ImagePath);
            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, 
                this.Phone, this.Email, this.NationalityCountryID, this.Address, this.ImagePath);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdatePerson();
                    }
            }

            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static clsPerson Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "", NationalNo ="";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            short Gender = -1;

            if (clsPersonData.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                    ref Gender, ref Phone, ref Email, ref NationalityCountryID, ref Address, ref ImagePath))

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                    Gender, Phone, Email, NationalityCountryID, Address, ImagePath);
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1, PersonID = -1;
            short Gender = -1;

            if (clsPersonData.GetGetPersonInfoByNationalNo(ref PersonID, NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                    ref Gender, ref Phone, ref Email, ref NationalityCountryID, ref Address, ref ImagePath)) 

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                    Gender, Phone, Email, NationalityCountryID, Address, ImagePath);
            else
                return null;
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNum)
        {
            return clsPersonData.IsPersonExist(NationalNum);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();

        }
    }
}
