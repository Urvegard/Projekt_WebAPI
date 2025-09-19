using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_WebAPI.Data;
using Projekt_WebAPI.DTOs;
using Projekt_WebAPI.Models;

namespace Projekt_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedGeneratorController : ControllerBase
    {
        private readonly SeedGenerator _seeder;
        public SeedGeneratorController(SeedGenerator generator)
        {
            _seeder = generator;
        }
        [HttpGet ("ClearDataBase")]
        public async Task<ActionResult> ClearDatabase()
        {
            var result = await _seeder.ClearDatabase();
            
            return Ok(result);
        }
    }
}
