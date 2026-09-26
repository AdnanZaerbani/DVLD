using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD_System___DataAccessLayer
{
    public class clsDetainedLicenseData
    {
        public static bool GetDetainInfoByLicenseID(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT        DetainID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID\r\nFROM            DetainedLicenses\r\nWHERE DetainedLicenses.LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];


                    if (reader["ReleaseDate"] != DBNull.Value)
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    else
                        ReleaseDate = DateTime.Now;

                    if (reader["ReleasedByUserID"] != DBNull.Value)
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    else
                        ReleasedByUserID = -1;

                    if (reader["ReleaseApplicationID"] != DBNull.Value)
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                    else
                        ReleaseApplicationID = -1;
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

        public static int AddNewDetain(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int DetainID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID) 
                             VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID); 
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            
            if (ReleaseDate != DateTime.Now)
            {
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);
            }

            if (ReleasedByUserID != -1)
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);
            }

            if (ReleaseApplicationID != -1)
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DetainID = insertedID;
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

            return DetainID;
        }

        public static bool UpdateDetainRelease(int LicenseID, bool IsReleased)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update DetainedLicenses
                             set IsReleased = @IsReleased 
                                 WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
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

        public static DataTable GetAllDetained()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT        DetainedLicenses.DetainID as [D.ID], Licenses.LicenseID as [L.ID], DetainedLicenses.DetainDate as [D.Date], DetainedLicenses.IsReleased as [Is Released], DetainedLicenses.FineFees as [Fine Fees], DetainedLicenses.ReleaseDate as [Release Date], People.NationalNo as [N.No.], People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName + ' ', '') + People.LastName as [Full Name], DetainedLicenses.ReleaseApplicationID as [Release App.ID]\r\nFROM            DetainedLicenses INNER JOIN\r\n                         Licenses ON DetainedLicenses.LicenseID = Licenses.LicenseID INNER JOIN\r\n                         Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN\r\n                         People ON Drivers.PersonID = People.PersonID";

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

        public static bool IsLicenseDetain(int LicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT DetainedLicenses.IsReleased FROM DetainedLicenses WHERE DetainedLicenses.LicenseID = @LicenseID AND DetainedLicenses.IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
