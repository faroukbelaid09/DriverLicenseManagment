using Microsoft.Data.SqlClient;
using ModelsLayer;
using System.Data;

namespace DLMDataLayer
{
    public class clsUserDataAccess
    {
        public static bool CheckIfUserExists(int personID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CheckIfUserExists", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", personID);

                    // Add return parameter
                    SqlParameter returnParam = new SqlParameter();
                    returnParam.Direction = ParameterDirection.ReturnValue;
                    returnParam.ParameterName = "@ReturnValue";
                    cmd.Parameters.Add(returnParam);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    int returnValue = (int)returnParam.Value;

                    return returnValue == 1;
                }
            }
        }

        public static bool UserNameExists(string userName)
        {
            bool userExist = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("UserNameExists", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = userName;
                        conn.Open();

                        userExist = (int)cmd.ExecuteScalar() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return userExist;
        }

        public static List<UserDTO> GetUsers()
        {
            List<UserDTO> users = new List<UserDTO>();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetUsers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new UserDTO(
                                reader.GetInt32(reader.GetOrdinal("UserID")),
                                reader.GetInt32(reader.GetOrdinal("PersonID")),
                                reader.GetString(reader.GetOrdinal("UserName")),
                                reader.GetString(reader.GetOrdinal("FullName")),
                                reader.GetBoolean(reader.GetOrdinal("IsActive"))
                                ));
                        }
                    }
                }
            }
            return users;
        }

        public static UserAuthDTO GetUserForAuthentication(string username)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetUserForAuthentication", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", username);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        if (reader.Read())
                        {
                            return new UserAuthDTO
                                (
                                    reader.GetInt32(reader.GetOrdinal("UserID")),
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetBoolean(reader.GetOrdinal("IsActive"))
                                );
                        }
                    }
                }
            }
            return null;
        }

        public static int AddUser(CreateUserDTO createUserDTO)
        {
            int UserID = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AddUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID", createUserDTO.PersonID);
                        cmd.Parameters.AddWithValue("@UserName", createUserDTO.UserName);
                        cmd.Parameters.AddWithValue("@Password", createUserDTO.Password);
                        cmd.Parameters.AddWithValue("@IsActive", createUserDTO.IsActive);
                        conn.Open();

                        UserID =  Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return UserID;
        }
        
        /*
        public static bool FindUserByUserNameAndPassword(ref int userID, ref int personID, ref string username, ref string password, ref bool isActive)
        {
            bool userFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = "select * from Users where UserName = @username and Password = @password";

            SqlCommand command = new SqlCommand(query, connection);

            Console.WriteLine("USN: " + username);
            Console.WriteLine("PASS: " + password);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())

                {
                    userID = (int)reader["UserID"];
                    personID = (int)reader["PersonID"];
                    username = (string)reader["UserName"];
                    //fullname = (string)reader["FullName"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];

                    userFound = true;
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection?.Close();
            }

            return userFound;
        }

        

        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {
            bool isUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Users 
                           Set UserName = @UserName, Password = @Password,IsActive = @IsActive
                           Where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    isUpdated = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("DB: Error when updating user." + ex.ToString());
            }
            finally
            {
                connection?.Close();
            }

            return isUpdated;
        }

        public static bool DeleteUser(int UserID)
        {
            bool isDeleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Delete from Users where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    isDeleted = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("DB: Error when deleting this user.");
            }
            finally
            {
                connection?.Close();
            }
            return isDeleted;
        }
        */
    }
}