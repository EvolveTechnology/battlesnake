using Microsoft.AspNetCore.Mvc;
using NetSnake.Model;

namespace NetSnake
{
    [Route("")]
    public class SnakeController : Controller
    {
        [HttpPost]
        [Route("start")]
        public IActionResult Start([FromBody] Game game)
        {
            return Ok(new Configuration());
        }

        [HttpPost]
        [Route("move")]
        public IActionResult Move([FromBody] Game game)
        {
            return Ok();
        }
    }
}