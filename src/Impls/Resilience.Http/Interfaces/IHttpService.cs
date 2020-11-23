using System.Threading.Tasks;
using Resilience.Http.Models;

namespace Resilience.Http.Interfaces
{
    public interface IHttpService
    {
        // Get请求
        string Get(HttpUrl url, bool forceHttp = false);
        Task<string> GetAsync(HttpUrl url, bool forceHttp = false);
        T GetJson<T>(HttpUrl url, bool forceHttp = false);
        Task<T> GetJsonAsync<T>(HttpUrl url, bool forceHttp = false);
        T GetXml<T>(HttpUrl url, bool forceHttp = false);
        Task<T> GetXmlAsync<T>(HttpUrl url, bool forceHttp = false);
        
        // Post请求
        string Post(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        Task<string> PostAsync(HttpUrl url, HttpUrl postData, bool forceHttp = false);

        // Put请求

        // Delete请求
    }
}