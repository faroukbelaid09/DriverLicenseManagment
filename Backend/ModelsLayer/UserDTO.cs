namespace ModelsLayer
{
    public class UserDTO
    {
        public int UserID { get; set; }
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
}
