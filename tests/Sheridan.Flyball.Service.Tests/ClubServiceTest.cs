using AutoFixture.Xunit2;
using Moq;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Core.ViewModels.Create;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Service.Tests
{
    public class ClubServiceTest
    {
        [Fact]
        public void CreateClub_ValidMapping()
        {
            var newClub = new CreateClubModel() { Name = "T", NafaClubNumber = 1 };

            var club = new Club() { Id = 1, NafaClubNumber = newClub.NafaClubNumber, Name = newClub.Name };

            var clubRepoMock = new Mock<IClubRepository>();
            var personRepoMock = new Mock<IPersonRepository>();
            var dogRepoMock = new Mock<IDogRepository>();
            clubRepoMock.Setup(_ => _.AddAndSave(club)).Returns(club);

            var sut = new ClubService(clubRepoMock.Object, personRepoMock.Object, dogRepoMock.Object);

            var results = sut.CreateClub(newClub);

            club.NafaClubNumber.ShouldBe(newClub.NafaClubNumber);
            club.Name.ShouldBe(newClub.Name);
        }

        [Fact]
        public void CreatePerson_ValidMapping()
        {
            var newPerson = new CreatePersonModel() {ClubId = 1,LastName = "1",FirstName = "2"};

            var person = new Person() { Id = 1, ClubId = newPerson.ClubId,FirstName = newPerson.FirstName,LastName = newPerson.LastName};

            var clubRepoMock = new Mock<IClubRepository>();
            var personRepoMock = new Mock<IPersonRepository>();
            var dogRepoMock = new Mock<IDogRepository>();
            personRepoMock.Setup(_ => _.AddAndSave(person)).Returns(person);

            var sut = new ClubService(clubRepoMock.Object, personRepoMock.Object, dogRepoMock.Object);

            var results = sut.CreatePerson(newPerson);

            person.ClubId.ShouldBe(newPerson.ClubId);
            person.FirstName.ShouldBe(newPerson.FirstName);
            person.LastName.ShouldBe(newPerson.LastName);
        }

        [Theory]
        [InlineAutoData()]
        public void CreatePerson_PersonOnClub(Club club, Person person)
        {
            var newPerson = new CreatePersonModel()
                {ClubId = club.Id, FirstName = person.FirstName, LastName = person.LastName};

            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var helper = new TestHelper(methodName);

            var sut = new ClubService(helper.SetupClubRepository(),helper.SetupPersonRepository(),helper.SetupDogRepository());



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
