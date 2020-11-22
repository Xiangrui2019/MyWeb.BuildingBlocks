using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ServiceDiscoveryWebApp;
using Xunit;

namespace ServiceDiscovery.FunctionalTests
{
    public class ServiceReslover_Tests : IDisposable
    {
        private readonly IHost _server;
        private readonly HttpClient _client;

        public ServiceReslover_Tests()
        {
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
        public async Task TestServiceReslover()
        {
            var result = await _client.GetAsync("http://localhost:15000/Test/Reslover");
            var message = JsonConvert.DeserializeObject<List<string>>(
                result.Content.ReadAsStringAsync().Result);
            
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("A", message.First());
        }

        public void Dispose()
        {
            _server.StopAsync().GetAwaiter().GetResult();
            _server.Dispose();
        }
    }
}