using DLMBusinessLayer;
using DLMDataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ModelsLayer;

namespace DriverLicenseManagmentAPI.Controllers
{
    [Route("api/drivers")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        [HttpGet("All",Name = "GetDrivers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DriverDTO>> GetDrivers()
        {
            List<DriverDTO> drivers = clsDrive.GetDrivers();

            if (drivers.Count == 0) 
            {
                return NotFound("No drivers were founds.");
            }

            return Ok(drivers);
        }



        [HttpGet("{id}", Name = "GetDriverById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DriverDTO> GetDriverById(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Invalid Driver ID.");
            }

            DriverDTO driver = clsDrive.FindDriverById(id);

            if (driver == null) 
            {
                NotFound("Driver were not found.");
            }

            return Ok(driver);
        }



        [HttpGet("by-person-id/{id}", Name = "GetDriverByPersonId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DriverDTO> GetDriverByPersonId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Driver ID.");
            }

            DriverDTO driver = clsDrive.FindDriverByPersonId(id);

            if (driver == null)
            {
                NotFound("Driver were not found.");
            }

            return Ok(driver);
        }



        [HttpGet("get-id/{id}", Name = "GetDriversID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<int> GetDriversID(int id)
        {
            int driverID = clsDrive.GetDriverID(id);

            if(driverID == -1)
            {
                return NotFound("Driver not found.");
            }

            return Ok(driverID);
        }



        [HttpPost(Name = "CreateDriver")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DriverDTO> CreateDriver(CreateDriverDTO driver) 
        {
            if (driver == null) 
            {
                return BadRequest("Invalid driver object.");
            }

            int createdDriverID = clsDrive.CreateDriver(driver);

            if (createdDriverID == -1) 
            {
                return BadRequest("An error accord when adding the driver.");
            }

            var createdDriver = clsDrive.FindDriverById(createdDriverID);

            if (createdDriver == null)
                return StatusCode(500, "Driver created but could not be retrieved.");

            return CreatedAtAction(
                nameof(GetDriverById),          // Action name
                new { id = createdDriverID },   // Route parameters
                createdDriver                   // Response body
            );
        }
    }
}