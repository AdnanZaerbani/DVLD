using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___DataAccessLayer
{
    public class clsDriverData
    {
        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate) 
                             VALUES (@PersonID, @CreatedByUserID, @CreatedDate); 
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DriverID = insertedID;
                }
                else
                {
                    return -1;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return DriverID;

        }

        public static DataTable GetAllDriver()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT DISTINCT Drivers.DriverID as [Driver ID], People.PersonID as [Person ID], People.NationalNo as [National No.], People.FirstName + ' ' +People.SecondName + ' ' +ISNULL(People.ThirdName, '') + ' ' +People.LastName AS [Full Name], LicenseClasses.ClassName as [License Class Name], Drivers.CreatedDate as [Date], Licenses.IsActive as [Active License] FROM            Drivers INNER JOIN                         People ON Drivers.PersonID = People.PersonID INNER JOIN                        Licenses ON Drivers.DriverID = Licenses.DriverID INNER JOIN                        LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
    }
}
