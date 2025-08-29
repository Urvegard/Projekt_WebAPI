using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projekt_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetAllCountries()
        { 
            try 
            { 
                var country = "test"; return Ok(country); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            } 
        }
    }
}
