using System.Linq;
using AutoFixture.Xunit2;
using Moq;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.Data.EFCore.Repositories;
using Sheridan.Flyball.Service;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Integration.Services
{
    public class ClubServiceTest
    {
        


        [Theory]
        [InlineAutoData()]
        public void CreateClub_OneClubCreated(CreateClubModel newClub)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var inMemorySetup = new InMemoryDbSetup(methodName);

            var sut = new ClubService(inMemorySetup.ClubRepository(), inMemorySetup.PersonRepository(), inMemorySetup.DogRepository());

            var results = sut.CreateClub(newClub).Result;

            results.NafaClubNumber.ShouldBe(newClub.NafaClubNumber);
            results.Name.ShouldBe(newClub.Name);
        }

        [Theory]
        [InlineAutoData()]
        public void CreatePerson_PersonOnClub(CreatePersonModel newPerson)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var inMemorySetup = new InMemoryDbSetup(methodName);

            var club = ModelSetup.SetupClub();
            newPerson.ClubId = club.Id;
            inMemorySetup.ClubRepository().AddAndSave(club);

            var sut = new ClubService(inMemorySetup.ClubRepository(), inMemorySetup.PersonRepository(), inMemorySetup.DogRepository());

            var results = sut.CreatePerson(newPerson).Result;

            results.People.Count().ShouldBe(1);

        }

        [Theory]
        [InlineAutoData()]
        public void CreatePerson_ClubDoesNotExists_ReturnsNull(CreatePersonModel newPerson)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var inMemorySetup = new InMemoryDbSetup(methodName);

            var club = ModelSetup.SetupClub();
            newPerson.ClubId = club.Id+1;
            inMemorySetup.ClubRepository().AddAndSave(club);

            var sut = new ClubService(inMemorySetup.ClubRepository(), inMemorySetup.PersonRepository(), inMemorySetup.DogRepository());

            var results = sut.CreatePerson(newPerson).Result;

            results.ShouldBeNull();

        }

        //[Fact]
        //public void CreateDog_ValidMapping()
        //{
        //    var newClub = new CreateClubModel() { Name = "T", NafaClubNumber = 1 };

        //    var club = new Club() { Id = 1, NafaClubNumber = newClub.NafaClubNumber, Name = newClub.Name };

        //    var clubRepoMock = new Mock<IClubRepository>();
        //    var personRepoMock = new Mock<IPersonRepository>();
        //    var dogRepoMock = new Mock<IDogRepository>();
        //    clubRepoMock.Setup(_ => _.AddAndSave(club)).Returns(club);

        //    var sut = new ClubService(clubRepoMock.Object, personRepoMock.Object, dogRepoMock.Object);

        //    var results = sut.CreateClub(newClub);

        //    club.NafaClubNumber.ShouldBe(newClub.NafaClubNumber);
        //    club.Name.ShouldBe(newClub.Name);
        //}
    }
}
