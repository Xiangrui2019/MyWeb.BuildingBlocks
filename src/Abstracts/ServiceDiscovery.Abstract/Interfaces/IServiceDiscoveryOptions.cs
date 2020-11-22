namespace ServiceDiscovery.Abstract.Interfaces
{
    public class IServiceDiscoveryOptions
    {
        string ModuleName { get; set; }
        
        string ServiceName { get; set; }

        string HealthCheckTemplate { get; set; }
    }
}