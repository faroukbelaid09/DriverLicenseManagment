using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class CreatePersonDTO
        {
            [Required(ErrorMessage = "National number is required.")]
            [StringLength(20, MinimumLength = 1, ErrorMessage = "National number must be between 1 and 20 characters.")]
            public string NationalNo { get; set; }

            [Required(ErrorMessage = "First name is required.")]
            [StringLength(10, ErrorMessage = "First name cannot exceed 20 characters.")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last name is required.")]
            [StringLength(10, ErrorMessage = "Last name cannot exceed 20 characters.")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Gender is required.")]
            [Range(0, 1, ErrorMessage = "Gender must be either 0 (Male) or 1 (Female).")]
            public int Gender { get; set; }

            [Required(ErrorMessage = "Phone number is required.")]
            [Phone(ErrorMessage = "Invalid phone number format.")]
            [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
            public string Phone { get; set; }

            public string Email { get; set; } 

            [Required(ErrorMessage = "Address is required.")]
            [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters.")]
            public string Address { get; set; }

            [Required(ErrorMessage = "Date of birth is required.")]
            [DataType(DataType.Date)]
            [Display(Name = "Date of Birth")]
            public DateTime DateOfBirth { get; set; }

            [Required(ErrorMessage = "Country ID is required.")]
            public int CountryID { get; set; } = 1;

            public string ImagePath { get; set; }

            public CreatePersonDTO(string NationalNo, string FirstName, string LastName, int Gender, string Phone,
                string Address, DateTime DateOfBirth, int CountryId, string ImagePath, string Email)
            {
                this.NationalNo = NationalNo;
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.Gender = Gender;
                this.Phone = Phone;
                this.Email = Email;
                this.Address = Address;
                this.DateOfBirth = DateOfBirth;
                this.CountryID = CountryId;
                this.ImagePath = ImagePath;
            }
        }

    public class UpdatePersonDTO
    {
        [Required(ErrorMessage = "Person ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Person ID")]
        public int PersonID { get; set; }

        [Required(ErrorMessage = "National number is required.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "National number must be between 1 and 20 characters.")]
        public string NationalNo { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(10, ErrorMessage = "First name cannot exceed 20 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(10, ErrorMessage = "Last name cannot exceed 20 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [Range(0, 1, ErrorMessage = "Gender must be either 0 (Male) or 1 (Female).")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        public string Phone { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Country ID is required.")]
        public int CountryID { get; set; } = 1;

        public string ImagePath { get; set; }
        public UpdatePersonDTO(int personID, string NationalNo, string FirstName, string LastName, int Gender, string Phone,
            string Address, DateTime DateOfBirth, int CountryId, string ImagePath, string Email)
        {
            this.PersonID = personID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryId;
            this.ImagePath = ImagePath;
        }
    }
}
