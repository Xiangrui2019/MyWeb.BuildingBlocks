using System.Threading.Tasks;
using Resilience.Http.Models;

namespace Resilience.Http.Interfaces
{
    public interface IHttpService
    {
        // Get请求
        string Get(HttpUrl url, bool forceHttp = false);
        Task<string> GetAsync(HttpUrl url, bool forceHttp = false);
        T GetToJson<T>(HttpUrl url, bool forceHttp = false);
        Task<T> GetToJsonAsync<T>(HttpUrl url, bool forceHttp = false);
        
        // Post请求
        string PostForm(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        Task<string> PostFormAsync(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        T PostFormToJson<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        Task<T> PostFormToJsonAsync<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        
        string PostJson(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        Task<string> PostJsonAsync(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        T PostJsonToJson<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        Task<T> PostJsonToJsonAsync<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false);

        // Put请求
        string PutJson(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        Task<string> PutJsonAsync(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        T PutJsonToJson<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        Task<T> PutJsonToJsonAsync<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        
        // Delete请求
        string DeleteJson(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        Task<string> DeleteJsonAsync(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        T DeleteJsonToJson<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false);
        Task<T> DeleteJsonToJsonAsync<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false);
    }
}