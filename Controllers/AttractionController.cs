using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projekt_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetAllAttractions()
        { 
            try 
            { 
                var attractions = "test"; return Ok(attractions); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            } 
        }
    }
}
