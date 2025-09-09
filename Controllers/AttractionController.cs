using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_WebAPI.Models;
using Projekt_WebAPI.Services;

namespace Projekt_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        private readonly AttractionService _service;

        public AttractionController(AttractionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attraction>>> GetAllAttractions()
        {
            try
            {
                var attraction = await _service.AllAttractions();

                return Ok(attraction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Attraction>> PostAttraction(Attraction attraction)
        {
            var result = await _service.AddAttraction(attraction);

            return Ok(attraction);
        }

        [HttpGet("GetAttractionsByCategory")]
        public async Task<ActionResult<Attraction>> GetAttractionsByCategory(string category)
        {
            var result = await _service.FilterAttractionByCategory(category);

            return Ok(result);
        }
        [HttpGet("GetAttractionsByCountry")]
        public async Task<ICollection<Attraction>> GetAttractionsByCountry(string Country)
        {
            var result = await _service.FilterAttractionByCountry(Country);

            return result;
        }
        [HttpGet("GetAttractionsByName")]
        public async Task<ICollection<Attraction>> GetAttractionsByName(string Name)
        {
            var result = await _service.FilterAttractionByName(Name);

            return result;
        }
        [HttpGet("GetAttractionsByDescription")]
        public async Task<ICollection<Attraction>> GetAttractionsByDescription(string Description)
        {
            var result = await _service.FilterAttractionByDescription(Description);

            return result;
        }
        [HttpGet("GetAttractionsByCity")]
        public async Task<ICollection<Attraction>> GetAttractionsByCity(string City)
        {
            var result = await _service.FilterAttractionByCity(City);

            return result;
        }
        [HttpGet("GetAttractionsWhereNoComment")]
        public async Task<ICollection<Attraction>> GetAttractionsWhereNoComment()
        {
            var result = await _service.FilterAttractionWhereNoComment();

            return result;
        }
        [HttpGet("GetAttractionByID")]
        public async Task<Attraction> GetAttractionByID(int Attractionid)
        {
            var result = await _service.FindAttractionByID(Attractionid);

            return result;
        }
    }
}

//[HttpGet]
//public async Task<ActionResult<string>> GetAllAttractions()
//{
//    try
//    {
//        var attractions = "test"; return Ok(attractions);
//    }
//    catch (Exception ex)
//    {
//        return StatusCode(500, $"Internal server error: {ex.Message}");
//    }
//}