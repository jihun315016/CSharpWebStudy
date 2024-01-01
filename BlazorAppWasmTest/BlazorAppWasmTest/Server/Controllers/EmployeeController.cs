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

        [HttpGet]
        [Route("read")]
        public IEnumerable<Employee> GetEmployees()
        {
            // 테이블에 있는 데이터 리턴
            return this._postgresContext.Employees.ToList();
        }

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
       
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] Employee employee)
        {
            // 서버쪽에서도 받을때 body로부터 객체를 꺼내와야 함 -> [FromBody]

            // 업데이트니까 null 체크
            if (employee == null) 
            {
                return BadRequest();
            }
            
            try
            {
                this._postgresContext.Update(employee);
                this._postgresContext.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _postgresContext.Employees.FindAsync(id);
            if (employee == null) 
            {
                return NotFound();
            }


            try
            {
                this._postgresContext.Remove(employee);
                this._postgresContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
