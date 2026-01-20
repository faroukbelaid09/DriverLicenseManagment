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
    public class clsDriverDataAccess
    {
        public static int CreateDriver(CreateDriverDTO newDriverDTO)
        {
            int DriverID = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AddDriver", conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID", newDriverDTO.PersonID);
                        cmd.Parameters.AddWithValue("@CreatedByUserID", newDriverDTO.CreatedByUserID);
                        cmd.Parameters.AddWithValue("@CreatedDate", newDriverDTO.CreatedDate);

                        conn.Open();

                        DriverID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return DriverID;
        }

        public static DriverDTO FindDriver(int personId)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("FindDriver", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", personId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DriverDTO(
                                    reader.GetInt32(reader.GetOrdinal("DriverID")),
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetInt32(reader.GetOrdinal("CreatedByUserID")),
                                    reader.GetString(reader.GetOrdinal("CreatedDate"))
                                );
                        }
                    }
                }
            }
            return null;
        }

        public static int GetDriverID(int personId)
        {
            int DriverID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
            {
                using (SqlCommand cmd = new SqlCommand("GetDriverId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", personId);
                    conn.Open();

                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        DriverID = insertedID;
                    }
                }
            }
            
            return DriverID;
        }

        public static List<DriverDTO> GetDrivers()
        {
            List<DriverDTO> drivers = new List<DriverDTO>();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDrivers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            drivers.Add(new DriverDTO(
                                    reader.GetInt32(reader.GetOrdinal("DriverID")),
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetInt32(reader.GetOrdinal("CreatedByUserID")),
                                    reader.GetString(reader.GetOrdinal("CreatedDate"))
                                ));
                        }
                    }
                }
            }
            return people;
        }
    }
}