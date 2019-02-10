using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Sheridan.Flyball.UI.Web.Api;
using Xunit;

namespace Sheridan.Flyball.Tests.Integration.Web.Api
{
    public class ApiFixture : IClassFixture<CustomWebApplicationFactory<Startup>>,IDisposable
    {
        public readonly HttpClient Client;

        public ApiFixture(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        public HttpResponseMessage PostResponse(string url,object model)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = Client.PostAsync(url, jsonContent).Result;

            return response;
        }

        public T PostResult<T>(string url, object model)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = Client.PostAsync(url, jsonContent).Result;
            response.EnsureSuccessStatusCode();
            var stringResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }

        public HttpResponseMessage GetResponse(string url)
        {
            var response = Client.GetAsync(url).Result;
            return response;
        }

        public T GetResult<T>(string url)
        {
            var response = Client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            var stringResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<T>(stringResponse);
            return result;
        }

        public HttpResponseMessage PutResponse(string url,object model)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = Client.PutAsync(url,jsonContent).Result;
            return response;
        }

        public T PutResult<T>(string url,object model)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = Client.PutAsync(url,jsonContent).Result;
            response.EnsureSuccessStatusCode();
            var stringResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<T>(stringResponse);
            return result;
        }

        public void Dispose()
        {
           Client.Dispose();
        }
    }
}