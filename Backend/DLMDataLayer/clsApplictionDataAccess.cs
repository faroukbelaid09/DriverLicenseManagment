using Microsoft.Data.SqlClient;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMDataLayer
{
    public class clsApplicationDataAccess
    {
        public static bool CheckIfApplicationExist(string nationalNo, string drivingClass)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CheckIfApplicationExist", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nationalNo", nationalNo);
                    cmd.Parameters.AddWithValue("@drivingClass", drivingClass);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // If there's at least one row, the application exists
                        return reader.HasRows;
                    }
                }
            }
        }

        public static ApplicationDTO FindApplication(int id)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("FindApplication", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@appID", id);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ApplicationDTO
                                (
                                reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                                reader.GetInt32(reader.GetOrdinal("ApplicantPersonID")),
                                reader.GetDateTime(reader.GetOrdinal("ApplicationDate")),
                                reader.GetInt32(reader.GetOrdinal("ApplicationTypeID")),
                                reader.GetInt32(reader.GetOrdinal("ApplicationStatus")),
                                reader.GetDateTime(reader.GetOrdinal("LastStatusDate")),
                                reader.GetInt32(reader.GetOrdinal("PaidFees")),
                                reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                                );
                        }
                    }
                }
            }
            return null;
        }

        public static int CreateApplication(CreateApplicationDTO createApplicationDTO)
        {
            int applicationID = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("CreateApplication", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ApplicantPersonID", createApplicationDTO.ApplicantPersonID);
                        cmd.Parameters.AddWithValue("@ApplicationDate", createApplicationDTO.ApplicationDate);
                        cmd.Parameters.AddWithValue("@ApplicationTypeID", createApplicationDTO.ApplicationTypeID);
                        cmd.Parameters.AddWithValue("@ApplicationStatus", createApplicationDTO.ApplicationStatus);
                        cmd.Parameters.AddWithValue("@LastStatusDate", createApplicationDTO.LastStatusDate);
                        cmd.Parameters.AddWithValue("@PaidFees", createApplicationDTO.PaidFees);
                        cmd.Parameters.AddWithValue("@CreatedByUserID", createApplicationDTO.CreatedByUserID);
                        conn.Open();

                        applicationID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return applicationID;
        }

        public static bool UpdateApplicationStatus(UpdateApplicationDTO updateApplicationDTO)
        {
            bool isUpdated = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateApplicationStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@appID", updateApplicationDTO.ApplicationID);
                    cmd.Parameters.AddWithValue("@appStatus", updateApplicationDTO.ApplicationStatus);

                    conn.Open();

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (rowAffected > 0)
                    {
                        isUpdated = true;
                    }
                }
            }

            return isUpdated;
        }
    }
}