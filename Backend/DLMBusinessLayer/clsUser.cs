using DLMDataLayer;
using ModelsLayer;

namespace DLMBusinessLayer
{
    public class clsUser
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public UserDTO userDTO { get
            {
                return (new UserDTO(this.UserID, this.PersonID, this.UserName, this.FullName, this.IsActive));
            } 
        }

        public clsUser() { }

        public clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
        }

        public static bool CheckIfUserExist(int personID)
        {
            return clsUserDataAccess.CheckIfUserExists(personID);
        }

        /*
        public int Add()
        {
            int userID = clsUserDataAccess.AddUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return userID;
        }
        public bool Update()
        {
            return clsUserDataAccess.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
        }
        public bool Delete()
        {
            return clsUserDataAccess.DeleteUser(this.UserID);
        }
        
        public static List<clsUser> GetAllUsers()
        {

            List<clsUser> users = new List<clsUser>();

            DataTable dataTable = clsUserDataAccess.GetUsers();

            if (dataTable.Rows != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    // Extract data from the DataRow
                    int userID = Convert.ToInt32(row["UserID"]);
                    int personID = Convert.ToInt32(row["PersonID"]);
                    string userName = row["UserName"].ToString();
                    string fullName = row["FullName"].ToString();
                    string password = row["Password"].ToString();
                    bool isActive = Convert.ToBoolean(row["IsActive"]);

                    // Create a new clsPerson object and add it to the list
                    clsUser user = new clsUser(
                        userID,
                        personID,
                        userName,
                        fullName,
                        password,
                        isActive
                    );

                    users.Add(user);
                }

                return users;
            }

            return null;
        }
        public static clsUser FindUserByUserNameAndPassword(string username, string password)
        {
            int userID = -1, personID = -1;
            string userName = username, userPassword = password;
            bool isActive = false;

            clsUser user = null;
            if (clsUserDataAccess.FindUserByUserNameAndPassword(ref userID, ref personID, ref userName, ref userPassword, ref isActive))
            {
                // Create a new clsPerson object and add it to the list
                user = new clsUser(
                    userID,
                    personID,
                    userName,
                    userPassword,
                    isActive
                );
            }
            return user;
        }
        public static bool CheckIfUserNameExist(string userName)
        {
            return clsUserDataAccess.CheckIfUserNameExist(userName);
        }
        */
    }
}
