using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_WebAPI.Models;
using Projekt_WebAPI.Services;

namespace Projekt_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {  
        private readonly CityService _service;

        public CityController(CityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetAllCities()
        {
            try
            {
                var city = await _service.AllCities();

                return Ok(city);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            var result = await _service.AddCity(city);

            return Ok(city);
        }

    }
}

//[HttpGet]
//public async Task<ActionResult<string>> GetAllCities()
//{
//    try
//    {
//        var cities = "test"; return Ok(cities);
//    }
//    catch (Exception ex)
//    {
//        return StatusCode(500, $"Internal server error: {ex.Message}");
//    }
//}

//public CityController(ICityService cityService) { _cityService = cityService; }   