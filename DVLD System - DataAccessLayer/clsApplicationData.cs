using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_System___DataAccessLayer
{
    public class clsApplicationData
    {
       public static bool GetApplicationInfoByAppID(int AppID, ref int ApplicantPersonID, ref byte AppStatus, ref string AppTypeTitle, ref decimal AppFees, ref DateTime AppDate, ref DateTime LastStatusDate, ref string UserName, ref string FullName)
       {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT\r\n    Applications.ApplicantPersonID,\r\n    Applications.ApplicationStatus,\r\n    ApplicationTypes.ApplicationTypeTitle,\r\n    ApplicationTypes.ApplicationFees,\r\n    Applications.ApplicationDate,\r\n    Applications.LastStatusDate,\r\n    Users.UserName,\r\n\r\n    People.FirstName + ' ' +\r\n    People.SecondName + ' ' +\r\n    ISNULL(People.ThirdName, '') + ' ' +\r\n    People.LastName AS FullName\r\n\r\nFROM Applications\r\n\r\nINNER JOIN ApplicationTypes\r\n    ON Applications.ApplicationTypeID =\r\n       ApplicationTypes.ApplicationTypeID\r\n\r\nINNER JOIN Users\r\n    ON Applications.CreatedByUserID =\r\n       Users.UserID\r\n\r\nINNER JOIN People\r\n    ON Applications.ApplicantPersonID =\r\n       People.PersonID\r\n\r\nWHERE Applications.ApplicationID = @AppID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppID", AppID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    AppStatus = (byte)reader["ApplicationStatus"];
                    AppTypeTitle = (string)reader["ApplicationTypeTitle"];
                    AppFees = (decimal)reader["ApplicationFees"];
                    AppDate = (DateTime)reader["ApplicationDate"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    UserName = (string)reader["UserName"];
                    FullName = (string)reader["FullName"];
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
       public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
       {
            int ApplicationID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID) VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
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

            return ApplicationID;
        }

        public static bool UpdateApplicationStatus(int ApplicationID, byte ApplicationStatus)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Applications
                             set ApplicationStatus = @ApplicationStatus,
                                 LastStatusDate = @LastStatusDate
                                 WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        
    }
}
