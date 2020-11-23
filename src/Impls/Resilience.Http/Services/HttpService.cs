using System.Threading.Tasks;
using Resilience.Http.Interfaces;
using Resilience.Http.Models;

namespace Resilience.Http.Services
{
    public class HttpService : IHttpService
    {
        public string Get(HttpUrl url, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetAsync(HttpUrl url, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public T GetToJson<T>(HttpUrl url, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetJsonToAsync<T>(HttpUrl url, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public string PostForm(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> PostFormAsync(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public T PostFormToJson<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> PostFormToJsonAsync<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public string PostJson(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> PostJsonAsync(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public T PostJsonToJson<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> PostJsonToJsonAsync<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public string PutJson(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> PutJsonAsync(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public T PutJsonToJson<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> PutJsonToJsonAsync<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public string DeleteJson(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> DeleteJsonAsync(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public T DeleteJsonToJson<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> DeleteJsonToJsonAsync<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            throw new System.NotImplementedException();
        }
    }
}