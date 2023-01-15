using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeMindX.Services;
using System.Threading.Tasks;

namespace ResumeMindX.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IService _service;

        public AdminController(IService service)
        {
            _service = service;
        }
        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _service.GetUsers();
            return Ok(result);
        }

        [HttpGet("getResumes")]
        public async Task<IActionResult> GetResumes()
        {
            var result = await _service.GetResumes();
            return Ok(result);
        }
    }
}
