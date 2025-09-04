using Microsoft.AspNetCore.Mvc;
using Projekt_WebAPI.DTOs;
using Projekt_WebAPI.Models;
using Projekt_WebAPI.Services;

namespace Projekt_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        { 
            try 
            { 
                var user = await _service.AllUsers(); 
                
                return Ok(user); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            } 
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserDTO user)
        {
            var result = await _service.AddUser(user);

            return Ok(user);
        }
    }
}

///*return CreatedAtAction("GetUser", new { id = user.Id }, user)*/;