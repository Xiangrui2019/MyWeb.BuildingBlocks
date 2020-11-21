using Microsoft.AspNetCore.Mvc;
using SeedWork.Services;

namespace SeedWork.UnitTests.TestResources.TestControllers
{
    public class TestCannonController
    {
        private readonly CannonService _cannonService;

        public TestCannonController(
            CannonService cannonService)
        {
            _cannonService = cannonService;
        }

        public IActionResult DemoAction()
        {
            _cannonService.Fire<DemoService>(d => d.DoSomethingSlow());
            return null;
        }

        public IActionResult DemoActionAsync()
        {
            _cannonService.FireAsync<DemoService>(d => d.DoSomethingSlowAsync());
            return null;
        }
    }
}