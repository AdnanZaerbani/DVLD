using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___DataAccessLayer
{
    public class clsTestData
    {
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID) 
                             VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID); 
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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

            return TestID;
        }

        public static bool IsPersonPassed(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT        Tests.TestResult\r\nFROM            TestAppointments INNER JOIN\r\n                         Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID\r\n\t\t\t\t\t\t WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestAppointments.TestTypeID = @TestTypeID and Tests.TestResult = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);



            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}
