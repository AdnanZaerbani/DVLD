using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_System___DataAccessLayer
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassIDByClassName(string ClassName, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT " +
                           " LicenseClasses.LicenseClassID  " +
                           " FROM LicenseClasses  " +
                           " WHERE LicenseClasses.ClassName = @ClassName ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

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

        public static bool GetLicenseClassInofByLicenseClassID(int LicenseClassID, ref string ClassName, ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT " +
                           " LicenseClasses.ClassName, " +
                           " LicenseClasses.DefaultValidityLength, " +
                           " LicenseClasses.ClassFees " +
                           " FROM LicenseClasses  " +
                           " WHERE LicenseClasses.LicenseClassID = @LicenseClassID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ClassName = (string)reader["ClassName"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
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

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT LicenseClasses.ClassName FROM LicenseClasses";

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
