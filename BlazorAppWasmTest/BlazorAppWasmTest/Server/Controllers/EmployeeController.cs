using BlazorAppWasmTest.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorAppWasmTest.Shared;

namespace BlazorAppWasmTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private PostgresContext _postgresContext = new PostgresContext();

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            try
            {
                // db에 insert할 것
                // db에 crud를 해주는 친구가 바로 PostgresContext 클래스
                this._postgresContext.Add(employee); // db에 새로운 데이터 Insert
                this._postgresContext.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                // 500은 인터널 서버 에러
                return StatusCode(500, ex.Message);
            }
        }
    }
}
