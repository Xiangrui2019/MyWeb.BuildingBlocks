using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        
        public async Task<T> GetToJsonAsync<T>(HttpUrl url, bool forceHttp = false)
        {
            var response = await GetAsync(url, forceHttp);

            return JsonConvert.DeserializeObject<T>(response);
        }
        
        public string Get(HttpUrl url, bool forceHttp = false) 
            => GetAsync(url, forceHttp).Result;

        public T GetToJson<T>(HttpUrl url, bool forceHttp = false) 
            => GetToJsonAsync<T>(url, forceHttp).Result;
    
        public async Task<string> PostFormAsync(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            if (forceHttp && !url.IsLocalhost())
            {
                url.Address = _regex.Replace(url.Address, "http://");
            }

            var response = await HttpInvokeAsync(
                HttpMethod.Post,
                url.ToString(),
                new FormUrlEncodedContent(postData.Params));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new WebException($"The remote server returned unexpected status code: {response.StatusCode} - {response.ReasonPhrase}.");
            }
        }
        
        public async Task<T> PostFormToJsonAsync<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            var response = await PostFormAsync(url, postData, forceHttp);

            return JsonConvert.DeserializeObject<T>(response);
        }
        
        public string PostForm(HttpUrl url, HttpUrl postData, bool forceHttp = false) 
            => PostFormAsync(url, postData, forceHttp).Result;

        public T PostFormToJson<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false) =>
            PostFormToJsonAsync<T>(url, postData, forceHttp).Result;


        public string PostJson(HttpUrl url, HttpUrl postData, bool forceHttp = false) =>
            PostJsonAsync(url, postData, forceHttp).Result;

        public async Task<string> PostJsonAsync(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            if (forceHttp && !url.IsLocalhost())
            {
                url.Address = _regex.Replace(url.Address, "http://");
            }
            
            var headers = new Dictionary<string, string>();
            headers.Add("content-type", "application/json");

            var response = await HttpInvokeAsync(
                HttpMethod.Post,
                url.ToString(),
                new StringContent(JsonConvert.SerializeObject(postData.Params)),
                headers);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new WebException($"The remote server returned unexpected status code: {response.StatusCode} - {response.ReasonPhrase}.");
            }
        }

        public T PostJsonToJson<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false) 
            => PostJsonToJsonAsync<T>(url, postData, forceHttp).Result;

        public async Task<T> PostJsonToJsonAsync<T>(HttpUrl url, HttpUrl postData, bool forceHttp = false)
        {
            var response = await PostJsonAsync(url, postData, forceHttp);

            return JsonConvert.DeserializeObject<T>(response);
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
            HttpContent content,
            Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url.ToString())
            {
                Content = content,
            };
            request.Headers.Add("accept", "application/json, text/html");

            if (headers != null)
            {
                foreach (var header in headers.ToList())
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            using var response = await _httpClient.SendAsync(request);

            return response;
        }
    }
}