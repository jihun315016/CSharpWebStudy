using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            if (person == null)
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
    }
}
