using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.IServices;
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
    }
}
