using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.UI.Web.Api;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Integration.Web.Api
{
  
    public class ApiClubControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ApiClubControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public void CreateClub_Return400GivenInvalidRequest()
        {
            var createNewClub = new CreateClubModel() {Name = "Test", NafaClubNumber = -1};
            var jsonContent = new StringContent(JsonConvert.SerializeObject(createNewClub),Encoding.UTF8,"application/json");

            var response = _client.PostAsync("/api/club/createclub", jsonContent).Result;

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void CreatePerson_Return400GivenInvalidRequest()
        {
            var createNewPerson = new CreatePersonModel() { ClubId = 1, FirstName = "", LastName = "T" };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(createNewPerson), Encoding.UTF8, "application/json");

            var response = _client.PostAsync("/api/club/createperson", jsonContent).Result;

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void CreatePerson_Return400_GivenClubNotExist()
        {
            var createNewPerson = new CreatePersonModel() { ClubId=1,FirstName="Test",LastName="T" };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(createNewPerson), Encoding.UTF8, "application/json");

            var response = _client.PostAsync("/api/club/createperson", jsonContent).Result;

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void CreateClub_ReturnClubOnCreate()
        {
            int validId = 1;
            var createNewClub = new CreateClubModel() { Name = "Test", NafaClubNumber = validId };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(createNewClub), Encoding.UTF8, "application/json");

            var response = _client.PostAsync("/api/club/createclub", jsonContent).Result;
            response.EnsureSuccessStatusCode();
            var stringResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Club>(stringResponse);

            result.Id.ShouldBe(validId);
            result.Name.ShouldBe(createNewClub.Name);

        }
    }
}
