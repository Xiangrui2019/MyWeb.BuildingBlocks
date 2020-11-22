using System.Collections.Generic;

namespace LoadBalancer.Abstract
{
    public interface ILoadBalancer
    {
        string Endpoint(List<string> endpoints);
    }
}