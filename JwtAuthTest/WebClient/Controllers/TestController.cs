using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
