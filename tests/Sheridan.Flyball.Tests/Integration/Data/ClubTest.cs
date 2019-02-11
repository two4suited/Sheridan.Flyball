using System.Linq;
using AutoFixture.Xunit2;
using FlyballStatTracker.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Data.EFCore.Repositories;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Integration.Data
{
    public class ClubTest : IClassFixture<DatabaseFixture>
    {
        private IClubRepository _clubRepository;
        private readonly DatabaseFixture _fixture;

        public ClubTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
            
            _clubRepository = _fixture.ClubRepository();
        }
    }
}