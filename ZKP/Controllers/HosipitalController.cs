using Microsoft.AspNetCore.Mvc;
using ZKP.Services;
using ZKP.Models;
using ZKP.TestData;

namespace ZKP.Controllers
{
    [ApiController]
    [Route("api/hospital")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _service;

        public HospitalController(IHospitalService service)
        {
            _service = service;
        }

        [HttpGet("patient-info")]
        public IActionResult GetInfo([FromQuery] string phoneNumber)
        {

            var result = _service.GetPatientInfo(phoneNumber);
            return Ok(result);
        }
    }
}