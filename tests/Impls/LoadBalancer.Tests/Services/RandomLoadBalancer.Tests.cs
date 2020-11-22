using System.Collections.Generic;
using LoadBalancer.Abstract;
using LoadBalancer.Services;
using Xunit;

namespace LoadBalancer.Tests.Services
{
    public class RandomLoadBalancer_Tests
    {
        [Fact]
        public void TestLB()
        {
            ILoadBalancer lb = new RandomLoadBalancer();
            var list = new List<string>
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I"
            };

            Assert.NotEqual("A", lb.Endpoint(list));
            Assert.NotEqual("A", lb.Endpoint(list));
            Assert.NotEqual("A", lb.Endpoint(list));
        }
    }
}