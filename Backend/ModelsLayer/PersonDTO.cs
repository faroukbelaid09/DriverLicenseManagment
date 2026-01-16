using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class PersonDTO
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CountryName { get; set; }
        public string ImagePath { get; set; }
        public PersonDTO(int PersonID, string NationalNo, string FirstName, string LastName, int Gender, string Phone,
            string Address, DateTime DateOfBirth, string CountryName, string ImagePath, string Email)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender == 0 ? "Female" : "Male";
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryName = CountryName;
            this.ImagePath = ImagePath;
        }
    }
}
