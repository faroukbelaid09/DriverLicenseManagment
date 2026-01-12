namespace ModelsLayer
{
    public class UserDTO
    {
        //public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }

        public UserDTO(int userId, int personId, string userName, string fullName, bool isActive) 
        {
            this.UserID = userId;
            this.PersonID = personId;
            this.UserName = userName;
            this.FullName = fullName;
            this.IsActive = isActive;
        }
    }

    // For authentication/registration
    public class UserAuthDTO
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public UserAuthDTO(int userId, int personId, string userName, string password, bool isActive)
        {
            this.UserID = userId;
            this.PersonID = personId;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
        }
    }

    
    // For creating/updating users (including password)
    public class CreateUserDTO
    {
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public CreateUserDTO(int personId, string userName, string password, bool isActive)
        {
            this.PersonID = personId;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
        }

    }
}
