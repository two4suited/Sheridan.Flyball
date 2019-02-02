using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Xunit;

namespace Sheridan.Flyball.Data.EFCore.Tests
{
    public class DogRunTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(DogRun dogRun)
        {
            TestHelper.AddOne_ThenOne(dogRun, typeof(DogRun).Name);

        }
    }
}