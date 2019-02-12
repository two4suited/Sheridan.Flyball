using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Enumerations;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Core
{
    public class RaceTest
    {
        [Theory]
        [InlineAutoData(1, 1)]
        public void SetRaceNumber_WhenRaceNumber_ThenRaceNumber(int raceNumber, int expectedValue)
        {
            var race = new Race {RaceNumber = raceNumber};

            race.RaceNumber.ShouldBe(expectedValue);
        }

        [Fact]
      
        public void SetLaneSide_WhenLeft_ThenLeft()
        {
            var laneSide = LaneSide.Left;
            var expectedValue = LaneSide.Left;

            var race = new Race {LaneSide = laneSide};

            race.LaneSide.ShouldBe(expectedValue);
        }

        [Theory]
        [InlineAutoData()]
        public void AddHeat_ShouldBeOne(Race race, Heat heat)
        {
            race.Heats.Clear();
            race.AddHeat(heat);

            race.Heats.Count.ShouldBe(1);
        }
        //Set Lane Side
        //Get Heats
    }
}