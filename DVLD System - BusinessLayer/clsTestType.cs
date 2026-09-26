using DVLD_System___DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___BusinessLayer
{
    public class clsTestType
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public clsTestType()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = -1;
        }

        public clsTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        public static clsTestType Find(int TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            decimal TestTypeFees = -1;

            if (clsTestTypeData.GetTestTypeInfoByID(TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            else 
                return null;
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        public bool Save()
        {
            return _UpdateTestType();
        }

        public static DataTable GetAllTestType()
        {
            return clsTestTypeData.GetAllTestTypes();
        }
    }
}
