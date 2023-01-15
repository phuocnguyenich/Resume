using Microsoft.AspNetCore.Mvc;
using ResumeMindX.Domain;
using ResumeMindX.Services;
using System.Threading.Tasks;

namespace ResumeMindX.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService _service;

        public UserController(IService service)
        {
            _service = service;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] User user)
        {
            await _service.Signup(user);
            return Ok("User created successfully");
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var sucess = await _service.Login(user);
            if (sucess)
                return Ok("Login successfully.");
            return Ok("Login failed.");
        }
    }
}
