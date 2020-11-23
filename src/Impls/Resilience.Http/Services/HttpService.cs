using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Resilience.Http.Interfaces;
using Resilience.Http.Models;

namespace Resilience.Http.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly Regex _regex;
        
        public HttpService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient();
            _regex = new Regex("^https://", RegexOptions.Compiled);
        }
        
        public string Get(HttpUrl url, bool forceHttp = false)
        {
            
        }

        public async Task<string> GetAsync(HttpUrl url, bool forceHttp = false)
        {
            if (forceHttp && !url.IsLocalhost())
            {
                url.Address = _regex.Replace(url.Address, "http://");
            }

            var response = await HttpInvokeAsync(
                HttpMethod.Get,
                url.ToString(),
                new FormUrlEncodedContent(new Dictionary<string, string>()));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new WebException($"The remote server returned unexpected status code: {response.StatusCode} - {response.ReasonPhrase}.");
            }
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
        
        private async Task<HttpResponseMessage> HttpInvokeAsync(
            HttpMethod method,
            string url,
            HttpContent content)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url.ToString())
            {
                Content = content,
            };
            request.Headers.Add("accept", "application/json, text/html");

            using var response = await _httpClient.SendAsync(request);

            return response;
        }
    }
}