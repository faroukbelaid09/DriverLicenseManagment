using DLMDataLayer;
using ModelsLayer;

namespace DLMBusinessLayer
{
    public class clsPerson
    {
        public static PersonDTO FindPersonByID(int ID)
        {
            if (ID < 0) 
            {
                Console.WriteLine("Invalid ID.");

                return null;
            }

            PersonDTO person = clsPersonDataAccess.GetPersonById(ID);

            if (person != null)
            {
                return person;
            }
            return null;
        }
        
        public static PersonDTO FindPersonByNationalNo(string nationalNo)
        {
            if (string.IsNullOrEmpty(nationalNo))
            {
                Console.WriteLine("Invalid Country Name.");
                return null;
            }
            PersonDTO person = clsPersonDataAccess.GetPersonByNationalNo(nationalNo);
            if (person != null)
            {
                return person;
            }
            return null;
        }
        
        public static string GetPersonCountryName(int personID)
        {
            return clsPersonDataAccess.GetPersonCountryName(personID);
        }
        
        public static List<PersonDTO> GetAllPeople()
        {

            List<PersonDTO> people = clsPersonDataAccess.GetPeople();

            if (people.Count > 0)
            {
                return people;
            }

            return null;
        }
        
        public static PersonDTO Add(CreatePersonDTO newPerson)
        {
            ValidateNewPerson(newPerson);

            int ID = clsPersonDataAccess.AddPerson(newPerson);

            if (ID != -1)
            {
                return FindPersonByID(ID);
            }
            return null;
        }

        public static bool Update(UpdatePersonDTO updatePersonDTO)
        {
            return clsPersonDataAccess.UpdatePerson(updatePersonDTO);
        }
        
        public static bool Delete(int personID)
        {
            if (personID < 0) 
            {
                return false;
            }
            return clsPersonDataAccess.DeletePerson(personID);
        }
        


        private static void ValidateNewPerson(CreatePersonDTO createPersonDTO)
        {
            if (string.IsNullOrWhiteSpace(createPersonDTO.FirstName))
                throw new Exception("FirstName is required");

            if (string.IsNullOrWhiteSpace(createPersonDTO.LastName))
                throw new Exception("LastName is required");

            if (string.IsNullOrWhiteSpace(createPersonDTO.Address))
                throw new Exception("Address is required");

            if (string.IsNullOrWhiteSpace(createPersonDTO.Phone))
                throw new Exception("Phone is required");
        }
    }
}