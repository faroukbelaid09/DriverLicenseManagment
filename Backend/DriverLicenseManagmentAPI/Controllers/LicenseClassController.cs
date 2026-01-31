using DLMBusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;

namespace DriverLicenseManagmentAPI.Controllers
{
    [Route("api/LicenseClass")]
    [ApiController]
    public class LicenseClassController : ControllerBase
    {
        [HttpGet("All", Name = "GetLicenseClasses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<LicenseClassDTO>> GetLicenseClasses()
        {
            List<LicenseClassDTO> licenseClasses = clsLicenseClass.GetLicenseClasses();

            if (licenseClasses.Count <= 0)
            {
                return BadRequest("No license classes were found.");
            }

            return Ok(licenseClasses);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LicenseClassDTO> GetLicenseClassByName(string name) 
        {
            if (string.IsNullOrEmpty(name)) 
            {
                return BadRequest("Invalid class name.");
            }

            LicenseClassDTO licensClass = clsLicenseClass.GetLicenseClass(name);

            if (licensClass == null) 
            {
                return NotFound("license class was not found.");
            }

            return Ok(licensClass);
        }

        [HttpGet("All-Classes-Names", Name = "GetLicenseClassesNames")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<string>> GetLicenseClassesNames()
        {
            List<string> licenseClassesNames = clsLicenseClass.GetClassesNames();

            if (licenseClassesNames.Count <= 0)
            {
                return BadRequest("No license classes names were found.");
            }

            return Ok(licenseClassesNames);
        }

    }
}
