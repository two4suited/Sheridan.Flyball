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
    public class ClubTest
    { 
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
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var context = InMemoryDbSetup.GetContext(methodName);
            var clubRepository = InMemoryDbSetup.ClubRepository(context);

            var dogs = clubRepository.GetDogs(1).Result;

            dogs.ShouldBeNull();
        }

        [Fact]
        public void GetDogs_ClubFoundNoDogs_ReturnEmptyList()
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var context = InMemoryDbSetup.GetContext(methodName);
            var clubRepository = InMemoryDbSetup.ClubRepository(context);

            context.Clubs.Add(ModelSetup.RipItUp);
            context.SaveChanges();
            
            var dogs = clubRepository.GetDogs(ModelSetup.RipItUp.Id).Result;

            dogs.Count.ShouldBe(0);
        }

        [Fact]
        public void GetDogs_ClubHasDogs_ReturnCountOfDogs()
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var context = InMemoryDbSetup.GetContext(methodName);
            var clubRepository = InMemoryDbSetup.ClubRepository(context);

            var club = ModelSetup.RipItUp;
            var person = ModelSetup.BrianSheridan;

            person.AddDog(ModelSetup.Bree);
            person.AddDog(ModelSetup.Decibel);
            club.AddPerson(person);
           

            context.Clubs.Add(club);
            context.SaveChanges();
            
            var sut = clubRepository.GetDogs(ModelSetup.RipItUp.Id).Result;

            sut.Count.ShouldBe(2);
        }
    }
}