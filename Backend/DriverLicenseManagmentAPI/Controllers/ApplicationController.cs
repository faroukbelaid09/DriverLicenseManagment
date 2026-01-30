using DLMBusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;

namespace DriverLicenseManagmentAPI.Controllers
{
    [Route("api/Application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllLocalApplications")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<LocalApplicationDTO>> GetAllLocalApplications()
        {
            List<LocalApplicationDTO> localAppplications = clsApplication.GetApplications();

            if (localAppplications == null)
            {
                return NotFound("No local application were found.");
            }

            return Ok(localAppplications);
        }



        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ApplicationDTO> FindApplicationByID(int id) 
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id.");
            }

            ApplicationDTO app = clsApplication.Find(id);

            return Ok(app);
        }



        [HttpPost(Name = "CreateApplication")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApplicationDTO> CreateApplication(CreateApplicationDTO newApplication)
        {
            try
            {
                if (newApplication == null)
                {
                    return BadRequest("Invalid values entered.");
                }

                int newAppId = clsApplication.Create(newApplication);
                if (newAppId == -1)
                {
                    return BadRequest("An error accord when creating the application.");
                }

                var createdApp = clsApplication.Find(newAppId);

                if (createdApp == null)
                    return StatusCode(500, "Application created but could not be retrieved.");

                return CreatedAtAction(nameof(FindApplicationByID), new { id = createdApp },
                    createdApp);
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while creating the application.");
            }
        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateApplication(int id, [FromBody] UpdateApplicationDTO updateApplication)
        {
            try
            {
                // Verify ID in route matches ID in DTO
                if (id != updateApplication.ApplicationID)
                {
                    return BadRequest("Application ID mismatch.");
                }

                bool updated = clsApplication.Update(updateApplication);

                if (!updated)
                {
                    return NotFound($"Application with ID {id} not found.");
                }

                // 204 No Content - successful update, no response body needed
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while updating the application.");
            }
        }
    }
}