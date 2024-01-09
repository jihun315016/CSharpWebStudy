using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebApplication1.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        // https://localhost:7075/api/Coffee/post
        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> Post([FromBody] Coffee coffee)
        {
            if (coffee  == null)
            {
                return BadRequest();
            }

            try
            {
                // 필요한 작업 처리
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // https://localhost:7075/api/Coffee/get?id=2
        [HttpGet]
        [Route("get")]
        public IEnumerable<Coffee> Get(int id)
        {
            return new List<Coffee>()
            {
                new Coffee() { Name = "aaa", Price = 3500 },
                new Coffee() { Name = "ccc", Price = 2000 }
            };
        }
    }
}
