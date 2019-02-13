using System.Linq;
using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Core
{
    public class TeamTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddRace_WhenRaceAdded_OneTeam(Team team,Dog dog)
        {
            team.Dogs.ToList().Clear();
            team.AddDog(dog);

            team.Dogs.ToList().Count.ShouldBe(1);
        }
    }
}