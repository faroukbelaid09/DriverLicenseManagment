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
    public class clsLicenseClassDataAccess
    {
        public List<LicenseClassDTO> GetLicenseClasses()
        {
            List<LicenseClassDTO> licenseClasses = new List<LicenseClassDTO>();

            using(SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("GetLicenseClasses", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            licenseClasses.Add(new LicenseClassDTO(
                                reader.GetInt32(reader.GetOrdinal("LicenseClassID")),
                                reader.GetString(reader.GetOrdinal("ClassName")),
                                reader.GetString(reader.GetOrdinal("ClassDescription")),
                                reader.GetInt32(reader.GetOrdinal("MinimumAllowedAge")),
                                reader.GetInt32(reader.GetOrdinal("DefaultValidityLength")),
                                reader.GetInt32(reader.GetOrdinal("ClassFees"))
                                ));
                        }
                    }
                }
            }

            return licenseClasses;
        }


        public LicenseClassDTO GetLicenseClassByName(string className) 
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetClassByName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@className", className);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return new LicenseClassDTO(
                                reader.GetInt32(reader.GetOrdinal("LicenseClassID")),
                                reader.GetString(reader.GetOrdinal("ClassName")),
                                reader.GetString(reader.GetOrdinal("ClassDescription")),
                                reader.GetInt32(reader.GetOrdinal("MinimumAllowedAge")),
                                reader.GetInt32(reader.GetOrdinal("DefaultValidityLength")),
                                reader.GetInt32(reader.GetOrdinal("ClassFees"))
                                );
                        }
                    }
                }
            }

            return null;
        }
    
    
        public List<string> GetClassesNames()
        {
            List<string> classesNames = new List<string>();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetLicenseClasses", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            classesNames.Add(
                                reader.GetString(reader.GetOrdinal("ClassName"))
                                );
                        }
                    }
                }
            }

            return classesNames;
        }
    }
}