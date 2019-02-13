using FlyballStatTracker.Data.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Data.EFCore.Repositories;

namespace Sheridan.Flyball.Tests.Integration
{
    public class InMemoryDbFixture : IDisposable
    {
        public  FlyballDbContext Context;
        public InMemoryDbFixture()
        {
            var options = new DbContextOptionsBuilder<FlyballDbContext>()
                .UseInMemoryDatabase(databaseName:"InMemoryTesting")
                .Options;

            Context = new FlyballDbContext(options);
           // SeedData.PopulateTestData(Context);

            Context.Database.EnsureCreated();
        }

       

        public IClubRepository ClubRepository()
        {
            return new ClubRepository(Context);
        }
        public IPersonRepository PersonRepository()
        {
            return new PersonRepository(Context);
        }
        public IDogRepository DogRepository()
        {
            return new DogRepository(Context);
        }


        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
