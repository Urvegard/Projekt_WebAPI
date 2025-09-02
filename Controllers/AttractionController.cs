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