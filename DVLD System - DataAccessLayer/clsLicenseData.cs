using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD_System___DataAccessLayer
{
    public class clsLicenseData
    {
        public static bool GetLicenseInfoByLicenseID(int LicenseID, ref string ClassName, ref string FullName, ref string NationalNo, ref byte Gender, ref DateTime IssueDate, ref byte IssueReason, ref string Notes, ref bool IsActive, ref DateTime DateOfBirth, ref int DriverID, ref DateTime ExpirationDate, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                             SELECT

                             LicenseClasses.ClassName,
                             
                             People.FirstName + ' ' +
                             People.SecondName + ' ' +
                             ISNULL(People.ThirdName, '') + ' ' +
                             People.LastName AS FullName,
                             Licenses.LicenseID,
                             People.NationalNo,
                             People.Gender,
                             Licenses.IssueDate,
                             Licenses.IssueReason,
                             Licenses.Notes,
                             Licenses.IsActive,
                             People.DateOfBirth,
                             Drivers.DriverID,
                             Licenses.ExpirationDate,
                             People.ImagePath
                             
                             FROM Licenses
                             
                             INNER JOIN Drivers
                             ON Licenses.DriverID = Drivers.DriverID
                             
                             INNER JOIN People
                             ON Drivers.PersonID = People.PersonID
                             
                             INNER JOIN LicenseClasses
                             ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                             
                             WHERE Licenses.LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ClassName = (string)reader["ClassName"];
                    FullName = (string)reader["FullName"];
                    NationalNo = (string)reader["NationalNo"];
                    Gender = (byte)reader["Gender"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    IssueReason = (byte)reader["IssueReason"];

                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["Notes"];
                    else
                        Notes = "";

                    IsActive = (bool)reader["IsActive"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    DriverID = (int)reader["DriverID"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";
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
        public static bool GetLicenseInfoByApplicationID(int ApplicationID, ref int LicenseID, ref string ClassName, ref string FullName, ref string NationalNo, ref byte Gender, ref DateTime IssueDate, ref byte IssueReason, ref string Notes, ref bool IsActive, ref DateTime DateOfBirth, ref int DriverID, ref DateTime ExpirationDate, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                             SELECT
                             Licenses.LicenseID,
                             LicenseClasses.ClassName,
                             
                             People.FirstName + ' ' +
                             People.SecondName + ' ' +
                             ISNULL(People.ThirdName, '') + ' ' +
                             People.LastName AS FullName,
                             
                             People.NationalNo,
                             People.Gender,
                             Licenses.IssueDate,
                             Licenses.IssueReason,
                             Licenses.Notes,
                             Licenses.IsActive,
                             People.DateOfBirth,
                             Drivers.DriverID,
                             Licenses.ExpirationDate,
                             People.ImagePath
                             
                             FROM Licenses
                             
                             INNER JOIN Drivers
                             ON Licenses.DriverID = Drivers.DriverID
                             
                             INNER JOIN People
                             ON Drivers.PersonID = People.PersonID
                             
                             INNER JOIN LicenseClasses
                             ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                             
                             WHERE Licenses.ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    ClassName = (string)reader["ClassName"];
                    FullName = (string)reader["FullName"];
                    NationalNo = (string)reader["NationalNo"];
                    Gender = (byte)reader["Gender"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    IssueReason = (byte)reader["IssueReason"];
                    
                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["Notes"];
                    else
                        Notes = "";

                    IsActive = (bool)reader["IsActive"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    DriverID = (int)reader["DriverID"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";
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

        public static bool GetApplicationIDByLicenseID(int LicenseID, ref int ApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT " +
                           "Licenses.ApplicationID " +
                           "FROM Licenses " +
                           "WHERE Licenses.LicenseID = @LicenseID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    
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
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID) 
                             VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);  
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes != "")
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
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

            return LicenseID;
        }

        public static bool UpdateLicenseActive(int LicenseID, bool IsActive)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Licenses
                             set IsActive = @IsActive 
                                 WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
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
        public static DataTable GetAllLicense(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT        Licenses.LicenseID as [License ID], Licenses.ApplicationID as [Application ID], LicenseClasses.ClassName as [Class Name], Licenses.IssueDate as [Issue Date], Licenses.ExpirationDate as [Expiration Date], Licenses.IsActive as [Is Active]\r\nFROM            Licenses INNER JOIN\r\n                         LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID INNER JOIN\r\n                         Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN\r\n                         People ON Drivers.PersonID = People.PersonID\r\n\t\t\t\t\t\t WHERE People.PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonHasLicense(int LicenseClass, int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT        Licenses.LicenseID, Applications.ApplicationID, People.PersonID, Licenses.LicenseClass\r\nFROM            Licenses INNER JOIN\r\n                         Applications ON Licenses.ApplicationID = Applications.ApplicationID INNER JOIN\r\n                         People ON Applications.ApplicantPersonID = People.PersonID\r\nWHERE        (People.PersonID = 1054) and Licenses.LicenseClass != LicenseClass";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

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
