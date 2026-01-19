using Microsoft.Data.SqlClient;
using ModelsLayer;
using System.Data;

namespace DLMDataLayer
{
    public class clsPersonDataAccess
    {
        public static PersonDTO GetPersonById(int id)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPersonById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", id);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int imagePathOrdinal = reader.GetOrdinal("ImagePath");
                            int emailOrdinal = reader.GetOrdinal("Email");

                            return new PersonDTO(
                                reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("NationalNo")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetInt32(reader.GetOrdinal("Gendor")),
                                    reader.GetString(reader.GetOrdinal("Phone")),
                                    reader.GetString(reader.GetOrdinal("Address")),
                                    reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                    reader.GetString(reader.GetOrdinal("CountryName")),

                                    reader.IsDBNull(imagePathOrdinal) ? null : reader.GetString(imagePathOrdinal),
                                    reader.IsDBNull(emailOrdinal) ? null : reader.GetString(emailOrdinal)

                                );
                        }
                    }
                }
            }
            return null;
        }

        public static PersonDTO GetPersonByNationalNo(string NationalNo)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPersonByNationalNo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int imagePathOrdinal = reader.GetOrdinal("ImagePath");
                            int emailOrdinal = reader.GetOrdinal("Email");

                            return new PersonDTO(
                                reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("NationalNo")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetInt32(reader.GetOrdinal("Gendor")),
                                    reader.GetString(reader.GetOrdinal("Phone")),
                                    reader.GetString(reader.GetOrdinal("Address")),
                                    reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                    reader.GetString(reader.GetOrdinal("CountryName")),

                                    reader.IsDBNull(imagePathOrdinal) ? null : reader.GetString(imagePathOrdinal),
                                    reader.IsDBNull(emailOrdinal) ? null : reader.GetString(emailOrdinal)

                                );
                        }
                    }
                }
            }
            return null;
        }

        public static string GetPersonCountryName(int CountryID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPersonCountryName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CountryID", CountryID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetString(reader.GetOrdinal("CountryName"));
                        }
                    }
                }
            }
            return null;
        }

        public static List<PersonDTO> GetPeople()
        {
            List<PersonDTO> people = new List<PersonDTO>();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPeople", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int imagePathOrdinal = reader.GetOrdinal("ImagePath");
                            int emailOrdinal = reader.GetOrdinal("Email");

                            people.Add(new PersonDTO(
                                reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("NationalNo")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetInt32(reader.GetOrdinal("Gendor")),
                                    reader.GetString(reader.GetOrdinal("Phone")),
                                    reader.GetString(reader.GetOrdinal("Address")),
                                    reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                    reader.GetString(reader.GetOrdinal("CountryName")),

                                    reader.IsDBNull(imagePathOrdinal) ? null : reader.GetString(imagePathOrdinal),
                                    reader.IsDBNull(emailOrdinal) ? null : reader.GetString(emailOrdinal)

                                ));
                        }
                    }
                }
            }
            return people;
        }

        public static int AddPerson(CreatePersonDTO createPersonDTO)
        {
            int PersonID = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AddPerson", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NationalNo", createPersonDTO.NationalNo);
                        cmd.Parameters.AddWithValue("@FirstName", createPersonDTO.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", createPersonDTO.LastName);
                        cmd.Parameters.AddWithValue("@DateOfBirth", createPersonDTO.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Gendor", createPersonDTO.Gender);
                        cmd.Parameters.AddWithValue("@Address", createPersonDTO.Address);
                        cmd.Parameters.AddWithValue("@Phone", createPersonDTO.Phone);
                        cmd.Parameters.AddWithValue("@NationalityCountryID", createPersonDTO.CountryID);

                        if (createPersonDTO.Email != null)
                        {
                            cmd.Parameters.AddWithValue("@Email", createPersonDTO.Email);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Email", System.DBNull.Value);
                        }

                        if (createPersonDTO.ImagePath != null)
                        {
                            cmd.Parameters.AddWithValue("@ImagePath", createPersonDTO.ImagePath);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
                        }
                            
                        conn.Open();

                        PersonID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return PersonID;
        }

        public static bool UpdatePerson(UpdatePersonDTO updatePersonDTO)
        {
            bool isUpdated = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePerson", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", updatePersonDTO.PersonID);
                    cmd.Parameters.AddWithValue("@NationalNo", updatePersonDTO.NationalNo);
                    cmd.Parameters.AddWithValue("@FirstName", updatePersonDTO.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", updatePersonDTO.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", updatePersonDTO.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gendor", updatePersonDTO.Gender);
                    cmd.Parameters.AddWithValue("@Address", updatePersonDTO.Address);
                    cmd.Parameters.AddWithValue("@Phone", updatePersonDTO.Phone);
                    cmd.Parameters.AddWithValue("@NationalityCountryID", updatePersonDTO.CountryID);

                    if (updatePersonDTO.Email != null)
                    {
                        cmd.Parameters.AddWithValue("@Email", updatePersonDTO.Email);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Email", System.DBNull.Value);
                    }

                    if (updatePersonDTO.ImagePath != null)
                    {
                        cmd.Parameters.AddWithValue("@ImagePath", updatePersonDTO.ImagePath);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
                    }

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

        public static bool DeletePerson(int personID)
        {
            bool isDeleted = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeletePerson", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", personID);
                    conn.Open();

                    isDeleted = cmd.ExecuteNonQuery() > 0;
                }
            }
            return isDeleted;
        }
    }
}