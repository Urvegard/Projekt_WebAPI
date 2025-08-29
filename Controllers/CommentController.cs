using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projekt_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetAllComments()
        {
            try
            {
                var comments = "test"; return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
