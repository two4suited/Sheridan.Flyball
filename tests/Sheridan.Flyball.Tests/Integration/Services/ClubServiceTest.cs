//using System.Linq;
//using AutoFixture.Xunit2;
//using Moq;
//using Sheridan.Flyball.Core.Entities;
//using Sheridan.Flyball.Core.Interfaces.Repository;
//using Sheridan.Flyball.Core.ViewModels.Create;
//using Sheridan.Flyball.Data.EFCore.Repositories;
//using Sheridan.Flyball.Service;
//using Shouldly;
//using Xunit;

//namespace Sheridan.Flyball.Tests.Integration.Services
//{
//    public class ClubServiceTest
//    {
        


//        [Theory]
//        [InlineAutoData()]
//        public void CreateClub_OneClubCreated(CreateClubModel newClub)
//        {
//            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
//            var inMemorySetup = new InMemoryDbSetup(methodName);

//            var sut = new ClubService(inMemorySetup.ClubRepository(), inMemorySetup.PersonRepository(), inMemorySetup.DogRepository());

//            var results = sut.Create(newClub).Result;

//            results.NafaClubNumber.ShouldBe(newClub.NafaClubNumber);
//            results.Name.ShouldBe(newClub.Name);
//        }

//        //THESE TEST NEED TO MOVE

//        //[Theory]
//        //[InlineAutoData()]
//        //public void CreatePerson_PersonOnClub(CreatePersonModel newPerson)
//        //{
//        //    var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
//        //    var inMemorySetup = new InMemoryDbSetup(methodName);

//        //    var club = ModelSetup.SetupClub();
//        //    newPerson.ClubId = club.Id;
//        //    inMemorySetup.ClubRepository().AddAndSave(club);

//        //    var sut = new ClubService(inMemorySetup.ClubRepository(), inMemorySetup.PersonRepository(), inMemorySetup.DogRepository());

//        //    var results = sut.CreatePerson(newPerson).Result;

//        //    results.People.Count().ShouldBe(1);

//        //}

//        //[Theory]
//        //[InlineAutoData()]
//        //public void CreatePerson_ClubDoesNotExists_ReturnsNull(CreatePersonModel newPerson)
//        //{
//        //    var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
//        //    var inMemorySetup = new InMemoryDbSetup(methodName);

//        //    var club = ModelSetup.SetupClub();
//        //    newPerson.ClubId = club.Id + 1;
//        //    inMemorySetup.ClubRepository().AddAndSave(club);

//        //    var sut = new ClubService(inMemorySetup.ClubRepository(), inMemorySetup.PersonRepository(), inMemorySetup.DogRepository());

//        //    var results = sut.CreatePerson(newPerson).Result;

//        //    results.ShouldBeNull();

//        //}


//    }
//}
