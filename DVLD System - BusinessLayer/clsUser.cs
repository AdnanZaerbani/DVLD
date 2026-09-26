using DVLD_System___DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___BusinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int UserID { set; get; }
        public int PersonID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public short IsActive { set; get; }

        public clsUser() 
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = -1;

            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, string UserName, string Password, short IsActive)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }
        private clsUser (int UserID, int PersonID, string UserName, string Password, short IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
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
                        return _UpdateUser();
                    }
            }

            return false;
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static clsUser Find(int UserID)
        {
            string UserName = "", Password = "";
            short IsActive = -1;

            if (clsUserData.GetUserInfoByID(UserID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUser Find(string UserName)
        {
            string Password = "";
            int PersonID = -1;
            int UserID = -1;
            short IsActive = -1;
            if (clsUserData.GetUserInfoByUserName(ref UserID, ref PersonID, UserName, ref Password, ref IsActive)) 
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool IsUserExist(string UserName, string Password)
        {
            return clsUserData.IsUserExist(UserName, Password);
        }

        public static bool IsUserActive(string UserName, short IsActive)
        {
            return clsUserData.IsUserActive(UserName, IsActive);
        }

        public static bool IsPersonHasUser(int PersonID)
        {
            return clsUserData.IsPersonHasUser(PersonID);
        }
    }
}
