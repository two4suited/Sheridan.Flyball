using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Xunit;

namespace Sheridan.Flyball.Data.EFCore.Tests
{
    public class RaceYearTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(RaceYear raceYear)
        {
            TestHelper.AddOne_ThenOne(raceYear, typeof(RaceYear).Name);

        }
    }
}