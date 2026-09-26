using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System___DataAccessLayer
{
    public class clsApplicationTypeData
    {
        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query =
                          "SELECT ApplicationTypes.ApplicationTypeTitle, " +
                          "ApplicationTypes.ApplicationFees " +
                          "FROM ApplicationTypes " +
                          "WHERE ApplicationTypes.ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToDecimal(reader["ApplicationFees"]);
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

        public static bool GetApplicationFeesByID(int ApplicationTypeID, ref decimal ApplicationFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT ApplicationTypes.ApplicationFees FROM ApplicationTypes WHERE ApplicationTypes.ApplicationTypeID = @ApplicationTypeID";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ApplicationFees = Convert.ToDecimal(reader["ApplicationFees"]);
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

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT ApplicationTypes.ApplicationTypeID as 'ID' , ApplicationTypes.ApplicationTypeTitle as 'Title' , ApplicationTypes.ApplicationFees as 'Fees' FROM ApplicationTypes";

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

        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update ApplicationTypes
                             set ApplicationTypeTitle = @ApplicationTypeTitle,
                                 ApplicationFees = @ApplicationFees
                                 WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

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
