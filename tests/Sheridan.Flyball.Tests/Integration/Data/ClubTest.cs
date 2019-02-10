using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Data.EFCore.Repositories;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Integration.Data
{
    public class ClubTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(Club club)
        {
            TestHelper.AddOne_ThenOne(club,typeof(Club).Name);
        }
        

        



    }
}