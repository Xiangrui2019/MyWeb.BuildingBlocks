using System;
using System.Collections.Generic;
using System.Linq;
using LoadBalancer.Abstract;

namespace LoadBalancer.Services
{
    public class RandomLoadBalancer : ILoadBalancer
    {
        public string Endpoint(List<string> endpoints)
        {
            return endpoints.ElementAt(
                Environment.TickCount % endpoints.Count());
        }
    }
}