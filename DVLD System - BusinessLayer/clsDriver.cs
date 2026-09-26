using DVLD_System___DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___BusinessLayer
{
    public class clsDriver
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatesDate { get; set; }

        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatesDate = DateTime.Now;
        }

        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatesDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatesDate = CreatesDate;
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatesDate);
            return (this.DriverID != -1);
        }

        public bool Save()
        {
            return _AddNewDriver();
        }

        public static DataTable GetAllDriver()
        {
            return clsDriverData.GetAllDriver();
        }
    }
}
