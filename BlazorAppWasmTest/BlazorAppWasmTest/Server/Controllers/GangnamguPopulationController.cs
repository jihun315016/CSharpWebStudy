using BlazorAppWasmTest.Server.Interfaces;
using BlazorAppWasmTest.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppWasmTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GangnamguPopulationController : ControllerBase
    {
        // 아까 인터페이스를 했으니까 이 컨트롤러에서는 인터페이스를 통해서 함수를 호출하면 된다.
        // 그래서 인터페이스 타입 객체를 만들어준다.
        private readonly IGangnamguPopulation _IGgangnamguPopulation;

        public GangnamguPopulationController(IGangnamguPopulation iGangnamguPopulation)
        {
            _IGgangnamguPopulation = iGangnamguPopulation;
        }

        [HttpGet]
        public IEnumerable<GangnamguPopulation> Get()
        {
            // API에서 GET을 호출하면 인터페이스를 타고가서 실제 기능 수행은 서비스 클래스쪽에서 하게 된다.
            return _IGgangnamguPopulation.GetAllGangnamguPopulations();
        }
    }
}
