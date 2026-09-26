using DVLD_System___DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___BusinessLayer
{
    public class clsApplicationType
    {
        public int ApplicationTypeID {  get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        public clsApplicationType() 
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = -1;
        }

        public clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
        }

        public clsApplicationType(int ApplicationTypeID, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationFees = ApplicationFees;
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationFees = -1;

            if (clsApplicationTypeData.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees)) 
                return new clsApplicationType(ApplicationTypeID,ApplicationTypeTitle,ApplicationFees);
            else
                return null;
        }

        public static clsApplicationType Find(short ApplicationTypeID)
        {
            decimal ApplicationFees = -1;

            if (clsApplicationTypeData.GetApplicationFeesByID(ApplicationTypeID, ref ApplicationFees))
                return new clsApplicationType(ApplicationTypeID, ApplicationFees);
            else
                return null;
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }

        public bool Save()
        {
            return _UpdateApplicationType();
        }

        public static DataTable GetAllApplicationType()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }
    }
}
