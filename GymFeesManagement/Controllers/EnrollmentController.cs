using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.IServices;
using GymFeesManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymFeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost("AddEnroll")]
        public async Task<IActionResult> AddEnroll(EnrollRequest enrollRequest)
        {
            try
            {
                var data = await _enrollmentService.AddEnroll(enrollRequest);
                return Ok(data);
            }
            catch(Exception ex) 
            { 
            return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllEnrolls")]
        public async Task<IActionResult> GetAllEnroll()
        {
            try {
                var data = await _enrollmentService.GetAllEnroll();
                return Ok(data);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllEnrollByMember/{id}")]
        public async Task<IActionResult> EnrollmentByMember(int id)
        {
            try
            {
                var data = await _enrollmentService.EnrollmentByMember(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteEnroll/{id}")]
        public async Task<IActionResult> DeleteEnroll(int id)
        {
            try
            {
                var data = await _enrollmentService.DeleteEnroll(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
