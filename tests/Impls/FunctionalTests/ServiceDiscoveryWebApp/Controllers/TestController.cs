using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceDiscovery.Abstract.Interfaces;

namespace ServiceDiscoveryWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly IServiceReslover _reslover;

        public TestController(IServiceReslover reslover)
        {
            _reslover = reslover;
        }

        public async Task<IActionResult> Test()
        {
            var services = await _reslover.ResloveServiceAsync("Test.Module", "TestService");
            return Json(services.Count);
        }
    }
}