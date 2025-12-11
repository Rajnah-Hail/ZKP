using Microsoft.AspNetCore.Mvc;
using ZKP.Services;
using ZKP.Models;
using ZKP.TestData;


namespace ZKP.Controllers
{
    [ApiController]
    [Route("api/entertainment")]
    public class EntertainmentController : ControllerBase
    {
        private readonly IEntertainmentService _service;

        public EntertainmentController(IEntertainmentService service)
        {
            _service = service;
        }

        [HttpGet("check-age")]
        public IActionResult CheckAge([FromQuery] string phoneNumber)
        {

            var result = _service.CheckIfAdult(phoneNumber);
            return Ok(result);
        }
    }
}