using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Xunit;

namespace Sheridan.Flyball.Data.EFCore.Tests
{
    public class DogPositionTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(DogPosition dogPosition)
        {
            TestHelper.AddOne_ThenOne(dogPosition, typeof(DogPosition).Name);

        }
    }
}