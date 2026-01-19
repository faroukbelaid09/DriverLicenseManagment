using DLMBusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;

namespace DriverLicenseManagementAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet(Name ="GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            try
            {
                List<UserDTO> allUsers = clsUser.GetUsers();

                return Ok(allUsers);
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while retrieving users.");
            }
        }



        [HttpGet("{id}",Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> GetUserById(int id) 
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid user ID.");

                UserDTO user = clsUser.GetUserById(id);

                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while retrieving the user.");
            }
        }



        [HttpPost(Name = "AddUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDTO> AddUser(CreateUserDTO newUser)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (newUser == null)
                {
                    return BadRequest("Invalid values entered.");
                }

                int newUserId = clsUser.Add(newUser);
                if (newUserId == -1)
                {
                    return BadRequest("An error accord when adding the user.");
                }

                var createdUser = clsUser.GetUserById(newUserId);

                if (createdUser == null)
                    return StatusCode(500, "User created but could not be retrieved.");

                return CreatedAtAction(nameof(GetUserById), new { id = newUserId },
                    createdUser);
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while creating the user.");
            }
        }




        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateUser(int id, [FromBody] UpdateUserProfileDTO updatedUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                    
                // Verify ID in route matches ID in DTO
                if (id != updatedUser.UserID) 
                {
                    return BadRequest("User ID mismatch.");
                }

                bool updated = clsUser.Update(updatedUser);

                if (!updated) 
                {
                    return NotFound($"User with ID {id} not found.");
                }

                // 204 No Content - successful update, no response body needed
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while updating the user.");
            }
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid user ID.");

                var deleted = clsUser.Delete(id);

                if (!deleted)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while updating the user.");
            }
        }
    }
}