using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SeedWork.Services;
using SeedWork.UnitTests.TestResources.TestControllers;
using Xunit;

namespace SeedWork.UnitTests.Services
{
    public class CannonService_Tests
    {
        private IServiceProvider _serviceProvider;
        
        public CannonService_Tests()
        {
            _serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<CannonService>()
                .AddTransient<DemoService>()
                .AddScoped<TestCannonController>()
                .BuildServiceProvider();
        }
        
        [Fact]
        public async Task TestCannon()
        {
            var controller = _serviceProvider.GetRequiredService<TestCannonController>();
            var startTime = DateTime.UtcNow;
            controller.DemoAction();
            var endTime = DateTime.UtcNow;
            Assert.True(endTime - startTime < TimeSpan.FromMilliseconds(1000), "Demo action should finish very fast.");
            Assert.False(DemoService.Done);
            await Task.Delay(300);
            Assert.True(DemoService.Done);
        }

        [Fact]
        public async Task TestCannonAsync()
        {
            var controller = _serviceProvider.GetRequiredService<TestCannonController>();
            var startTime = DateTime.UtcNow;
            controller.DemoActionAsync();
            var endTime = DateTime.UtcNow;
            Assert.True(endTime - startTime < TimeSpan.FromMilliseconds(1000), "Demo action should finish very fast.");
            Assert.False(DemoService.DoneAsync);
            await Task.Delay(300);
            Assert.True(DemoService.DoneAsync);
        }
    }
}