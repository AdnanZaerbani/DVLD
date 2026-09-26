using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DVLD_System___DataAccessLayer
{
    public class clsUserData
    {
        public static bool GetUserInfoByID(int UserID, ref string UserName, ref string Password, ref short IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT " +
                           " Users.UserName, " +
                           " Users.Password, " +
                           " Users.IsActive " +
                           " FROM Users " +
                           " WHERE Users.UserID = @UserID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = Convert.ToInt16(reader["IsActive"]);
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

        public static bool GetUserInfoByUserName(ref int UserID, ref int PersonID, string UserName, ref string Password, ref short IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT " +
                           " Users.UserID, " +
                           " Users.PersonID, " +
                           " Users.Password, " +
                           " Users.IsActive " +
                           " FROM Users " +
                           " WHERE Users.UserName = @UserName ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    IsActive = Convert.ToInt16(reader["IsActive"]);
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

        public static int AddNewUser(int PersonID, string UserName, string Password, short IsActive)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "INSERT INTO Users (PersonID, UserName, Password, IsActive) VALUES (@PersonID, @UserName, @Password, @IsActive); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
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

            return UserID;
        }

        public static bool UpdateUser(int UserID ,string UserName, string Password, short IsActive)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Users
                             set UserName = @UserName,
                                 Password = @Password,
                                 IsActive = @IsActive
                                 WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Users 
                                where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT\r\n    Users.UserID,\r\n    People.PersonID,\r\n    People.FirstName + ' ' +\r\n    People.SecondName + ' ' +\r\n    ISNULL(People.ThirdName + ' ', '') +\r\n    People.LastName AS FullName,\r\n    Users.UserName,\r\n    Users.IsActive\r\nFROM People\r\nINNER JOIN Users\r\n    ON People.PersonID = Users.PersonID";

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

        public static bool IsUserExist(string UserName, string Password)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Users.UserName, Users.Password FROM Users WHERE UserName = @UserName and Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"UserName", UserName);
            command.Parameters.AddWithValue(@"Password", Password);

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

        public static bool IsUserActive(string UserName, short IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Users.IsActive FROM Users WHERE UserName = @UserName and IsActive = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"UserName", UserName);
            command.Parameters.AddWithValue(@"IsActive", IsActive);


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

        public static bool IsPersonHasUser(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Users.PersonID FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"PersonID", PersonID);


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
