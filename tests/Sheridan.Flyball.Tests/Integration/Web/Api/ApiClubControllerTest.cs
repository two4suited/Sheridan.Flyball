using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.UI.Web.Api;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Integration.Web.Api
{
  
    public class ApiClubControllerTest : ApiFixture
    {
        private readonly HttpClient _client;
        


        public ApiClubControllerTest(CustomWebApplicationFactory<Startup> factory)  : base(factory)
        {
            _client = null;
           

        }

        [Fact]
        public void Create_Return400GivenInvalidRequest()
        {
            var createNewClub = new CreateClubModel() {Name = "Test", NafaClubNumber = -1};
            
            var response = PostResponse("api/club", createNewClub);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public void Create_ReturnClubOnCreate()
        {
            int validId = 1;
            var createNewClub = new CreateClubModel() { Name = "Test", NafaClubNumber = validId };
            
            var result = PostResult<Club>("/api/club", createNewClub);

            result.Id.ShouldBe(validId);
            result.Name.ShouldBe(createNewClub.Name);
        }

        [Fact]
        public void GetById_ClubNotExist_ReturnNoContent()
        {

            var response = GetResponse("/api/club/10");

            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }

        [Fact]
        public void GetById_ClubExist_ReturnOk()
        {
            var club = ModelSetup.SetupClubWithNoPeople();
            
            var response = GetResponse("/api/club/" + club.Id);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public void GetById_ClubExist_ReturnClub ()
        {
            var club = ModelSetup.SetupClubWithNoPeople();
            
            var result = GetResult<Club>("/api/club/" + club.Id);

            result.Id.ShouldBe(club.Id);
        }

        [Fact]
        public void Update_InvalidModel_Return400()
        {
            var club = ModelSetup.SetupClubWithNoPeople();
            club.NafaClubNumber = -1;

            var response = PutResponse("/api/club", club);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Update_IdNotFound_Return204()
        {
            var club = ModelSetup.SetupClubWithNoPeople();
            club.Id = 1;

            var response = PutResponse("/api/club", club);

            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }

        [Fact]
        public void Update_ValidUpdate_Return200()
        {
            var club = ModelSetup.SetupClubWithNoPeople();
            
            var response = PutResponse("/api/club", club);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public void Update_ValidUpdate_ReturnUpdateModel()
        {
            string newName = "Updated";

            var club = ModelSetup.SetupClubWithNoPeople();
            club.Name = newName;
            
            var result = PutResult<Club>("/api/club", club);

            result.Name.ShouldBe(newName);
        }

        [Fact]
        public void GetPeople_ClubDoesExist_Return204()
        {
            var clubId = 1;

            var response = GetResponse("/api/club/" + clubId + "/people");
            
            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }

        [Fact]
        public void GetPeople_ClubExistNoPeople_ReturnsEmptyList()
        {
            var club = ModelSetup.SetupClubWithNoPeople();
            
            var result = GetResult<Person>("/api/club/" + club.Id + "/people");

            result.ShouldBeNull();
        }

        [Fact]
        public void GetPeople_ClubExistNoPeople_ReturnsList()
        {
            var club = ModelSetup.SetupClubWithNoPeople();
    
            var result = GetResult<Person>("/api/club/" + club.Id + "/people");

            result.ShouldBeNull();
        }

        [Fact]
        public void GetPeople_ClubExistWithPeople_ReturnsList()
        {
            var club = ModelSetup.SetupClubWithPeople();

            var result = GetResult<List<Person>>("/api/club/" + club.Id + "/people");

            result.Count.ShouldBeGreaterThanOrEqualTo(1);
        }
    }
}
