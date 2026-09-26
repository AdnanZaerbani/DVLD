using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DVLD_System___DataAccessLayer
{
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref short Gender, ref string Phone, ref string Email, ref int NationalityCountryID, ref string Address, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query =
                        "SELECT " +
                        "People.NationalNo, " +
                        "People.FirstName, " +
                        "People.SecondName, " +
                        "People.ThirdName, " +
                        "People.LastName, " +
                        "People.DateOfBirth, " +
                        "People.Gender, " +
                        "People.Phone, " +
                        "People.Email, " +
                        "People.NationalityCountryID, " +
                        "People.Address, " +
                        "People.ImagePath " +
                        "FROM People " +
                        "WHERE People.PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gender = Convert.ToInt16(reader["Gender"]);

                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    Address = (string)reader["Address"];

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

        public static bool GetGetPersonInfoByNationalNo(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref short Gender, ref string Phone, ref string Email, ref int NationalityCountryID, ref string Address, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query =
                        "SELECT " +
                        "People.PersonID, " +
                        "People.FirstName, " +
                        "People.SecondName, " +
                        "People.ThirdName, " +
                        "People.LastName, " +
                        "People.DateOfBirth, " +
                        "People.Gender, " +
                        "People.Phone, " +
                        "People.Email, " +
                        "People.NationalityCountryID, " +
                        "People.Address, " +
                        "People.ImagePath " +
                        "FROM People " +
                        "WHERE People.NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gender = Convert.ToInt16(reader["Gender"]);

                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    Address = (string)reader["Address"];

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

        public static int AddNewPerson(string NationalNo,  string FirstName,  string SecondName,  string ThirdName,  string LastName,  DateTime DateOfBirth,
             short Gender,  string Phone,  string Email,  int NationalityCountryID,  string Address,  string ImagePath)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Phone, Email, NationalityCountryID, Address, ImagePath)
                             VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, @Phone, @Email, @NationalityCountryID, @Address, @ImagePath);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
            {
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@Address", Address);

            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
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

            return PersonID;
        }

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
             short Gender, string Phone, string Email, int NationalityCountryID, string Address, string ImagePath)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update People
                             set NationalNo = @NationalNo,
                                 FirstName = @FirstName,
                                 SecondName = @SecondName,
                                 ThirdName = @ThirdName,
                                 LastName = @LastName,
                                 DateOfBirth = @DateOfBirth,
                                 Gender = @Gender,
                                 Phone = @Phone,
                                 Email = @Email,
                                 NationalityCountryID = @NationalityCountryID,
                                 Address = @Address,
                                 ImagePath = @ImagePath
                                 WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "" && ThirdName != null)
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
            {
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "" && Email != null)
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@Address", Address);

            if (ImagePath != "" && ImagePath != null)
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

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

        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete People 
                                where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT People.PersonID FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExist(string NationalNum)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT People.NationalNo FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNum);

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

        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT People.PersonID as [Person ID], " +
               "People.NationalNo as [National No.], " +
               "People.FirstName as [First Name], " +
               "People.SecondName as [Second Name], " +
               "People.ThirdName as [Third Name], " +
               "People.LastName as [Last Name], " +
               "CASE " +
               "WHEN People.Gender = 0 THEN 'Male' " +
               "WHEN People.Gender = 1 THEN 'Female' " +
               "END AS Gender, " +
               "People.DateOfBirth as [Date Of Birth], " +
               "Countries.CountryName as [Nationality], " +
               "People.Phone, " +
               "People.Email " +
               "FROM People " +
               "INNER JOIN Countries " +
               "ON People.NationalityCountryID = Countries.CountryID";

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
