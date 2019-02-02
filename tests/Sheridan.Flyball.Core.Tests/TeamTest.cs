using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Core.Tests
{
    public class TeamTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddRace_WhenRaceAdded_OneTeam(Team team,Dog dog)
        {
            team.Dogs.Clear();
            team.AddDog(dog);

            team.Dogs.Count.ShouldBe(1);
        }
    }
}