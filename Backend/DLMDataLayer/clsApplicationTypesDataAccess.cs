using Microsoft.Data.SqlClient;
using ModelsLayer;
using System.Data;

namespace DLMDataLayer
{
    public class clsApplicationTypesDataAccess
    {
        public static List<ApplicationTypeDTO> GetAllApplicationTypes()
        {
            List<ApplicationTypeDTO> apps = new List<ApplicationTypeDTO>();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllApplicationTypes", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            apps.Add(new ApplicationTypeDTO(
                                    reader.GetInt32(reader.GetOrdinal("ApplicationTypeID")),
                                    reader.GetString(reader.GetOrdinal("ApplicationTypeTitle")),
                                    reader.GetInt32(reader.GetOrdinal("ApplicationFees"))
                                ));
                        }
                    }
                }
            }

            return apps;
        }

        public static bool UpdateApplicationType(ApplicationTypeDTO applicationTypeDTO)
        {
            bool isUpdated = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateApplicationType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AppID", applicationTypeDTO.ApplicationTypeID);
                    cmd.Parameters.AddWithValue("@AppTitle", applicationTypeDTO.ApplicationTypeTitle);
                    cmd.Parameters.AddWithValue("@AppFees", applicationTypeDTO.ApplicationFees);

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

        public static ApplicationTypeDTO GetApplicationTypeById(int appTypeId)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetApplicationTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppTypeID", appTypeId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ApplicationTypeDTO
                                (
                                    reader.GetInt32(reader.GetOrdinal("ApplicationTypeID")),
                                    reader.GetString(reader.GetOrdinal("ApplicationTypeTitle")),
                                    reader.GetInt32(reader.GetOrdinal("ApplicationFees"))
                                );
                        }
                    }
                }
            }
            return null;
        }
    }
}