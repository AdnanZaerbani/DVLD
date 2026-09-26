using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___DataAccessLayer
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static bool GetDLAppByID(int LDLAppID, ref string ClassName, ref int PassedTestCount)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT LocalDrivingLicenseApplications_View.ClassName, LocalDrivingLicenseApplications_View.PassedTestCount FROM LocalDrivingLicenseApplications_View WHERE LocalDrivingLicenseApplications_View.LocalDrivingLicenseApplicationID = @LDLAppID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ClassName = (string)reader["ClassName"];
                    PassedTestCount = (int)reader["PassedTestCount"];
        
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

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

        public static bool GetDLAppByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT LocalDrivingLicenseApplications.ApplicationID, LocalDrivingLicenseApplications.LicenseClassID FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

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

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) VALUES (@ApplicationID, @LicenseClassID); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LocalDrivingLicenseApplicationID = insertedID;
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

            return LocalDrivingLicenseApplicationID;
        }

        public static bool DeleteLDLApplication(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            try
            {
                connection.Open();

                // Get ApplicationID
                string query = @"
            SELECT ApplicationID
            FROM LocalDrivingLicenseApplications
            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue(
                    "@LocalDrivingLicenseApplicationID",
                    LocalDrivingLicenseApplicationID);

                object result = command.ExecuteScalar();

                if (result == null)
                    return false;

                ApplicationID = Convert.ToInt32(result);


                // Delete Tests
                query = @"
            DELETE FROM Tests
            WHERE TestAppointmentID IN
            (
                SELECT TestAppointmentID
                FROM TestAppointments
                WHERE LocalDrivingLicenseApplicationID =
                      @LocalDrivingLicenseApplicationID
            )";

                command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue(
                    "@LocalDrivingLicenseApplicationID",
                    LocalDrivingLicenseApplicationID);

                command.ExecuteNonQuery();


                // Delete TestAppointments
                query = @"
            DELETE FROM TestAppointments
            WHERE LocalDrivingLicenseApplicationID =
                  @LocalDrivingLicenseApplicationID";

                command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue(
                    "@LocalDrivingLicenseApplicationID",
                    LocalDrivingLicenseApplicationID);

                command.ExecuteNonQuery();


                // Delete LocalDrivingLicenseApplication
                query = @"
            DELETE FROM LocalDrivingLicenseApplications
            WHERE LocalDrivingLicenseApplicationID =
                  @LocalDrivingLicenseApplicationID";

                command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue(
                    "@LocalDrivingLicenseApplicationID",
                    LocalDrivingLicenseApplicationID);

                rowsAffected = command.ExecuteNonQuery();


                // Delete Application
                query = @"
            DELETE FROM Applications
            WHERE ApplicationID = @ApplicationID";

                command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue(
                    "@ApplicationID",
                    ApplicationID);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static DataTable GetAllLDLA()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query =
    "SELECT " +
    "dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID AS [L.D.L.AppID], " +
    "dbo.Applications.ApplicationID, " +
    "dbo.LicenseClasses.ClassName AS [Driving Class], " +
    "dbo.People.NationalNo AS [National No.], " +
    "dbo.People.FirstName + ' ' + " +
    "dbo.People.SecondName + ' ' + " +
    "ISNULL(dbo.People.ThirdName, '') + ' ' + " +
    "dbo.People.LastName AS [Full Name], " +
    "dbo.Applications.ApplicationDate AS [Application Date], " +
    "(SELECT COUNT(dbo.TestAppointments.TestTypeID) " +
    " FROM dbo.Tests " +
    " INNER JOIN dbo.TestAppointments " +
    " ON dbo.Tests.TestAppointmentID = dbo.TestAppointments.TestAppointmentID " +
    " WHERE dbo.TestAppointments.LocalDrivingLicenseApplicationID = " +
    " dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID " +
    " AND dbo.Tests.TestResult = 1) AS [Passed Tests], " +
    "CASE " +
    " WHEN dbo.Applications.ApplicationStatus = 1 THEN 'New' " +
    " WHEN dbo.Applications.ApplicationStatus = 2 THEN 'Cancelled' " +
    " WHEN dbo.Applications.ApplicationStatus = 3 THEN 'Completed' " +
    "END AS Status " +
    "FROM dbo.LocalDrivingLicenseApplications " +
    "INNER JOIN dbo.Applications " +
    " ON dbo.LocalDrivingLicenseApplications.ApplicationID = dbo.Applications.ApplicationID " +
    "INNER JOIN dbo.LicenseClasses " +
    " ON dbo.LocalDrivingLicenseApplications.LicenseClassID = dbo.LicenseClasses.LicenseClassID " +
    "INNER JOIN dbo.People " +
    " ON dbo.Applications.ApplicantPersonID = dbo.People.PersonID";

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

        public static bool IsPersonHasActiveApplication(int PersonID, int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query =
                @"SELECT 1
          FROM LocalDrivingLicenseApplications LDLA
          INNER JOIN Applications A
              ON LDLA.ApplicationID = A.ApplicationID
          WHERE A.ApplicantPersonID = @PersonID
            AND LDLA.LicenseClassID = @LicenseClassID
            AND A.ApplicationStatus = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

    }
}
