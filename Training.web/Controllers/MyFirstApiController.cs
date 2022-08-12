using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Training.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFirstApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new string[] { "hello", "world" });
        }
    }
}

