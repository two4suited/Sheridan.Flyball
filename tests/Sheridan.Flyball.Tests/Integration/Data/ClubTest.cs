using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Data.EFCore.Repositories;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Integration.Data
{
    public class ClubTest
    {
        private IClubRepository _clubRepository;

        public ClubTest()
        {
            var db = new InMemoryDbSetup("ClubTests");
            SeedData.PopulateTestData(db.Context);
            _clubRepository = db.ClubRepository();
        }

        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(Club club)
        {
            TestHelper.AddOne_ThenOne(club,typeof(Club).Name);
        }

        [Fact]
        public void GetPeople_ClubNotFound_ReturnNull()
        {
            var people = _clubRepository.GetPeople(1);

            people.ShouldBeNull();
        }


        

        



    }
}