using System.Linq;
using AutoFixture.Xunit2;
using FlyballStatTracker.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Data.EFCore.Repositories;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Integration.Data
{
    public class ClubTest : IClassFixture<InMemoryDbFixture>
    {
        private IClubRepository _clubRepository;
        private InMemoryDbFixture _fixture;

        public ClubTest(InMemoryDbFixture fixture) 
        {
            _fixture = fixture;
            
            _clubRepository = _fixture.ClubRepository();

            _fixture.Context.Clubs.Add(ModelSetup.RipItUp);

            _fixture.Context.SaveChanges();
        }

        //GetPeople
        //-Invalid Club Return null
        //-No dogs return empty list
        //-Has Dog Returns right count

        //GetTeamsFastestTime
        //-No Time returns null
        //-Returns Lowest Time


        [Fact]
        public void GetDogs_ClubNotFound_ReturnNull()
        {
            var dogs = _clubRepository.GetDogs(1).Result;

            dogs.ShouldBeNull();
        }

        [Fact]
        public void GetDogs_ClubFoundNoDogs_ReturnEmptyList()
        {
            var club = ModelSetup.RipItUp;
            var dogs = _clubRepository.GetDogs(club.Id).Result;

            dogs.Count.ShouldBe(0);
        }

        [Theory]
        [InlineAutoData()]
        public void GetDogs_ClubHasDogs_ReturnCountOfDogs(Dog dog1, Dog dog2)
        {

            var club = _fixture.Context.Clubs.Single(x => x.Id == ModelSetup.RipItUp.Id);
            club.AddPerson(ModelSetup.BrianSheridan);
            _fixture.Context.SaveChanges();

            var person = _fixture.Context.People.Single(x => x.Id == ModelSetup.BrianSheridan.Id);
            dog1.PersonId = person.Id;
            dog2.PersonId = person.Id;

            person.AddDog(dog1);
            person.AddDog(dog2);

            _fixture.Context.People.Update(person);
            _fixture.Context.SaveChanges();

            var sut = _clubRepository.GetDogs(100).Result;

            sut.Count.ShouldBe(2);
        }
    }
}