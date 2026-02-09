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
    public class clsLocalApplicationDataAccess
    {
        public static List<LocalApplicationDTO> GetAllLocalApplications()
        {
            List<LocalApplicationDTO> localApplications = new List<LocalApplicationDTO>();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllLocalApplications", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            localApplications.Add(new LocalApplicationDTO(
                                reader.GetInt32(reader.GetOrdinal("LocalDrivingLicenseApplicationID")),
                                reader.GetString(reader.GetOrdinal("DrivingClass")),
                                reader.GetString(reader.GetOrdinal("NationalNo")),
                                reader.GetString(reader.GetOrdinal("FullName")),
                                reader.GetDateTime(reader.GetOrdinal("ApplicationDate")),
                                reader.GetInt32(reader.GetOrdinal("PassedTests")),
                                reader.GetInt32(reader.GetOrdinal("ApplicationStatus"))
                                ));
                        }
                    }
                }
            }
            return localApplications;
        }

        public static int CreateLocalApplication(CreateLocalApplicationDTO createLocalApplicationDTO)
        {
            int localApplicationID = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("CreateLocalDrivingLicenseApplication", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ApplicationID", createLocalApplicationDTO.ApplicationID);
                        cmd.Parameters.AddWithValue("@LicenseClassID", createLocalApplicationDTO.LicenseClassID);
                        conn.Open();

                        localApplicationID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return localApplicationID;
        }

        public static FindLocalApplicationDTO FindLocalApplication(int localAppId)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("FindLocalApplication", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LocalAppID", localAppId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new FindLocalApplicationDTO
                                (
                                reader.GetInt32(reader.GetOrdinal("LocalDrivingLicenseApplicationID")),
                                reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                                reader.GetInt32(reader.GetOrdinal("LicenseClassID"))
                                );
                        }
                    }
                }
            }
            return null;
        }
    }
}
