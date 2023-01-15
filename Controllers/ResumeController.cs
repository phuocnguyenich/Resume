using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeMindX.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResumeMindX.Controllers
{
    [Route("api/resume")]
    [ApiController]
    [Authorize]
    public class ResumeController : ControllerBase
    {
        private readonly IService _service;

        public ResumeController(IService service)
        {
            _service = service;
        }

        [HttpGet("getResumesByUserId/{userId}")]
        public async Task<IActionResult> GetResumesByUserId([FromRoute] int userId)
        {
            var resumes = await _service.GetResumesByUserId(userId);
            return Ok(resumes);
        }

        [HttpPost("createResume")]
        public async Task<IActionResult> CreateResume([FromBody] Domain.Resume resume)
        {
            await _service.CreateResume(resume);
            return Ok("Resumes created successfully");
        }

        [HttpPost("createResumes")]
        public async Task<IActionResult> CreateResumes([FromBody] List<Domain.Resume> resumes)
        {
            await _service.CreateResumes(resumes);
            return Ok("Resumes created successfully");
        }

        [HttpPost("updateResume")]
        public async Task<IActionResult> UpdateResume([FromBody] Domain.Resume resume)
        {
            var success = await _service.UpdateResume(resume);
            if (success)
                return Ok("Resumes updated successfully");

            return Ok("Resumes update failed");
        }

        [HttpPost("deleteResume")]
        public async Task<IActionResult> DeleteResume([FromBody] int resumeId)
        {
            var success = await _service.DeleteResume(resumeId);

            if (success)
                return Ok("Resumes deleted successfully");

            return Ok("Resumes delete failed");
        }
    }
}
