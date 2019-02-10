﻿using System;
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
        public void Create_Return400GivenInvalidRequest()
        {
            var createNewClub = new CreateClubModel() {Name = "Test", NafaClubNumber = -1};
            var jsonContent = new StringContent(JsonConvert.SerializeObject(createNewClub),Encoding.UTF8,"application/json");

            var response = _client.PostAsync("/api/club", jsonContent).Result;

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public void Create_ReturnClubOnCreate()
        {
            int validId = 1;
            var createNewClub = new CreateClubModel() { Name = "Test", NafaClubNumber = validId };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(createNewClub), Encoding.UTF8, "application/json");

            var response = _client.PostAsync("/api/club", jsonContent).Result;
            response.EnsureSuccessStatusCode();
            var stringResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Club>(stringResponse);

            result.Id.ShouldBe(validId);
            result.Name.ShouldBe(createNewClub.Name);
        }

        [Fact]
        public void GetById_ClubNotExist_ReturnNoContent()
        {
            var db = new InMemoryDbSetup(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var clubRepository = db.ClubRepository();
            var club = db.SetupClub();
            clubRepository.AddAndSave(club);

            var response = _client.GetAsync("/api/club/10").Result;

            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }

        [Fact]
        public void GetById_ClubExist_ReturnOk()
        {
            var club = ModelSetup.SetupClub();

            var response = _client.GetAsync("/api/club/" + club.Id).Result;

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public void GetById_ClubExist_ReturnClub ()
        {
            var club = ModelSetup.SetupClub();

            var response = _client.GetAsync("/api/club/" + club.Id).Result;
            response.EnsureSuccessStatusCode();
            var stringResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Club>(stringResponse);

            result.Id.ShouldBe(club.Id);
        }

        [Fact]
        public void Update_InvalidModel_Return400()
        {
            var club = ModelSetup.SetupClub();
            club.NafaClubNumber = -1;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(club), Encoding.UTF8, "application/json");

            var response = _client.PutAsync("/api/club", jsonContent).Result;

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Update_IdNotFound_Return204()
        {
            var club = ModelSetup.SetupClub();
            club.Id = 1;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(club), Encoding.UTF8, "application/json");

            var response = _client.PutAsync("/api/club", jsonContent).Result;

            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }

        [Fact]
        public void Update_ValidUpdate_Return200()
        {
            var club = ModelSetup.SetupClub();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(club), Encoding.UTF8, "application/json");

            var response = _client.PutAsync("/api/club", jsonContent).Result;

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        public void Update_ValidUpdate_ReturnUpdateModel()
        {
            string newName = "Updated";

            var club = ModelSetup.SetupClub();
            club.Name = newName;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(club), Encoding.UTF8, "application/json");

            var response = _client.PutAsync("/api/club", jsonContent).Result;
            response.EnsureSuccessStatusCode();
            var stringResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Club>(stringResponse);

            result.Name.ShouldBe(newName);
        }
    }
}
