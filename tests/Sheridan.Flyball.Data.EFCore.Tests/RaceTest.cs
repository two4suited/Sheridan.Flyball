using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Xunit;

namespace Sheridan.Flyball.Data.EFCore.Tests
{
    public class RaceTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(Race race)
        {
            TestHelper.AddOne_ThenOne(race, typeof(Race).Name);

        }
    }
}