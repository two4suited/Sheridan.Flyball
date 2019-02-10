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


        public void Dispose()
        {
           Client.Dispose();
        }
    }
}