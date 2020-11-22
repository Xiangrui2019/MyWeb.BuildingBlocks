using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ServiceDiscoveryWebApp;
using Xunit;
using Xunit.Abstractions;

namespace ServiceDiscovery.FunctionalTests
{
    public class ServiceReslover_Tests : IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IHost _server;
        private readonly HttpClient _client;

        public ServiceReslover_Tests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _server = Host.CreateDefaultBuilder(new string[0])
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls($"http://localhost:15000");
                    webBuilder.UseStartup<Startup>();
                })
                .Build();

            _client = new HttpClient();

            _server.Start();
        }

        [Fact]
        public async Task Test()
        {
            Thread.Sleep(80000);
            
            var result = await _client.GetAsync("http://localhost:15000/test/test");

            Assert.Equal("1", await result.Content.ReadAsStringAsync());
        }

        public void Dispose()
        {
            _server.StopAsync().GetAwaiter().GetResult();
            _server.Dispose();
        }
    }
}