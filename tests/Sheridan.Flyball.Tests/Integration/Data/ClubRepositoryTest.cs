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
    public class ClubTest : IClassFixture<DatabaseFixture>
    {
        private IClubRepository _clubRepository;
        private DatabaseFixture _fixture;

        public ClubTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
            
            _clubRepository = _fixture.ClubRepository();
        }

       
        //[Fact]
        //public void GetPeople_ClubNotFound_ReturnNull()
        //{
        //    var people = _clubRepository.GetPeople(1).Result;

        //    people.ShouldBeNull();
        //}

        //[Fact]
        //public void GetPeople_ClubFoundNoPeople_ReturnBlankPeople()
        //{
        //    var club = ModelSetup.SetupClubWithNoPeople();
        //    var people = _clubRepository.GetPeople(club.Id).Result;

        //    people.Count.ShouldBe(0);
        //}

        //[Fact]
        //public void GetPeople_ClubFoundPeople_ReturnPeople()
        //{
         
        //    var club = ModelSetup.SetupClubWithPeople();
       
        //    var people = _clubRepository.GetPeople(club.Id).Result;

        //    people.Count.ShouldBeGreaterThanOrEqualTo(1);
        //}








    }
}