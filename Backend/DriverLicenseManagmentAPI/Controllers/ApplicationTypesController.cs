using DLMBusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;

namespace DriverLicenseManagmentAPI.Controllers
{
    [Route("api/ApplicationTypes")]
    [ApiController]
    public class ApplicationTypesController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllApplicationTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ApplicationTypeDTO>> GetAllApplicationTypes() 
        {
            List<ApplicationTypeDTO> applicationTypeDTOs = clsApplicationTypes.GetAllApplicationTypes();

            if (applicationTypeDTOs.Count <= 0) 
            {
                return NotFound("No application types were found.");
            }

            return Ok(applicationTypeDTOs);
        }



        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ApplicationTypeDTO> GetApplicationTypeById(int id) 
        {
            if (id <= 0) 
            {
                return BadRequest("Invalid id.");
            }

            ApplicationTypeDTO app = clsApplicationTypes.GetApplicationTypeById(id);

            return Ok(app);
        }



        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApplicationTypeDTO> UpdateApplicationType(int id, [FromBody] ApplicationTypeDTO app) 
        {
            try
            {
                if (id != app.ApplicationTypeID)
                {
                    return BadRequest("App type ID mismatch.");
                }

                bool isUpdated = clsApplicationTypes.UpdateApplicationTypes(app);

                if (!isUpdated)
                {
                    return NotFound($"Application type with ID {id} not found.");
                }

                ApplicationTypeDTO appTypeDTO = clsApplicationTypes.GetApplicationTypeById(app.ApplicationTypeID);

                return Ok(appTypeDTO);
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