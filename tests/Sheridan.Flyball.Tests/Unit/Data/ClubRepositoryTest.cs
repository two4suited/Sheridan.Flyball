using System;
using System.Collections.Generic;
using System.Text;
using FlyballStatTracker.Data.EfCore;
using Moq;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Data.EFCore.Repositories;
using Xunit;

namespace Sheridan.Flyball.Tests.Unit.Data
{
    public class ClubRepositoryTest
    {
        [Fact]
        public void GetDogs_NoDogs_ReturnsNull()
        {
            var club = ModelSetup.SetupClubWithNoPeople();

            var mockContext = new Mock<FlyballDbContext>();
            mockContext.Setup(c => c.Clubs).Returns()

            var sut = new ClubRepository(mockContext.Object);



        }
    }
}
