using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_WebAPI.Models;

namespace Projekt_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        //public CityController(ICityService cityService) { _cityService = cityService; }     

        [HttpGet]
        public async Task<ActionResult<string>> GetAllCities()
        { 
            try 
            { 
                var cities = "test"; return Ok(cities); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            } 
        }
    }
}
