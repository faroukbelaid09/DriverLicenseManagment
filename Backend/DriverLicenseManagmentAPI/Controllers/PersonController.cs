using DLMBusinessLayer;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;

namespace DriverLicenseManagmentAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet ("All", Name = "GetPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PersonDTO>> GetPeople()
        {
            List<PersonDTO> people = clsPerson.GetAllPeople();

            if (people.Count <= 0) 
            {
                return NotFound("No people were found.");
            }

            return Ok(people);
        }



        [HttpGet("by-id/{id}", Name = "GetPersonByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PersonDTO> GetPersonByID(int id) 
        {
            PersonDTO person = clsPerson.FindPersonByID(id);

            if (person == null) 
            {
                return NotFound("Person was not found.");
            }

            return Ok(person);
        }



        [HttpGet("by-national-no/{nationalNo}", Name = "GetPersonByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PersonDTO> GetPersonByNationalNo(string nationalNo)
        {
            if (string.IsNullOrEmpty(nationalNo))
            {
                return BadRequest("Invalid National number.");
            }
            PersonDTO person = clsPerson.FindPersonByNationalNo(nationalNo);

            if (person == null)
            {
                return NotFound("Person was not found.");
            }

            return Ok(person);
        }



        [HttpGet("country-id/{countryId}", Name = "GetPersonCountryName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> GetPersonCountryName(int countryId)
        {
            string countryName = clsPerson.GetPersonCountryName(countryId);

            if (string.IsNullOrEmpty(countryName))
            {
                return NotFound("Country was not found.");
            }

            return Ok(countryName);
        }


        [HttpPost(Name = "AddPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PersonDTO> AddPerson(CreatePersonDTO newPerson)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                PersonDTO createdPerson = clsPerson.Add(newPerson);

                if (createdPerson == null)
                {
                    return BadRequest("An error accord when adding the user.");
                }

                return CreatedAtAction(nameof(GetPersonByID), new { id = createdPerson.PersonID },
                        createdPerson);
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while creating a person.");
            }

        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdatePerson(int id, [FromBody] UpdatePersonDTO updatePerson)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Verify ID in route matches ID in DTO
                if (id != updatePerson.PersonID)
                {
                    return BadRequest("Person ID mismatch.");
                }

                bool updated = clsPerson.Update(updatePerson);

                if (!updated)
                {
                    return NotFound($"Person with ID {id} not found.");
                }

                // 204 No Content - successful update, no response body needed
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while updating the person.");
            }
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeletePerson(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid person ID.");

                var deleted = clsPerson.Delete(id);

                if (!deleted)
                {
                    return NotFound($"Person with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while updating the person.");
            }
        }
    }
}