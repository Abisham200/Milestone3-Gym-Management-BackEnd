using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymFeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymProgramController : ControllerBase
    {
        private readonly IGymProgramService _gymProgramService;

        public GymProgramController(IGymProgramService gymProgramService)
        {
            _gymProgramService = gymProgramService;
        }

        [HttpGet("GetPrograms")]
        public async Task<IActionResult> GetPrograms()
        {
            try
            {
                var data = await _gymProgramService.GetPrograms();
                return Ok(data);
            }
            catch (Exception ex) 
            {
            return BadRequest(ex.Message);
            }
           
        }

        // GET: api/Programs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgram(int id)
        {
            try
            {
                var data = await _gymProgramService.GetProgram(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Programs/5


        [HttpPut("programUpdate/{id}")]
        public async Task<IActionResult> UpdateProgram(int id, ProgramRequestDTO program)
        {
            try
            {
                var data = await _gymProgramService.UpdateProgram(program, id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        // POST: api/Programs

        [HttpPost]
        public async Task<IActionResult> PostProgram(ProgramRequestDTO programRequest)
        {
           
                var data = await _gymProgramService.PostProgram(programRequest);
                return Ok(data);
            
            


        }

        

        // DELETE: api/Programs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(int id)
        {

            try
            {
                var data = await _gymProgramService.DeleteProgram(id);
                return Ok(data);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            
        }

        
    }
}
