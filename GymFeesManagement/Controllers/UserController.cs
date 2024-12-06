using GymFeesManagement.Database;
using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IServices;
using GymFeesManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace GymFeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;

        public UserController(AppDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(UserRoles? role)
        {
            try
            {
                var data = await _userService.GetUsers(role);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUserByID/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var data = await _userService.GetUser(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                var data = await _userService.GetUserByEmail(email);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(int id,UserRequest userRequest)
        {
               try
                {
                    var data = await _userService.UpdateUser(id, userRequest);
                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRequest userRequest)
        {

            try
            {
                var data = await _userService.Register(userRequest);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(Login logInData)
        {
            try
            {
                var data = await _userService.LogIn(logInData);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var data = await _userService.DeleteUser(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-Roles")]
        public async Task<IActionResult> GetRoles()
        {
            var data = await _userService.GetRoles();
            return Ok(data);
        }
    }
}
