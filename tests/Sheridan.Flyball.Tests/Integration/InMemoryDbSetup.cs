using System;
using System.Collections.Generic;
using System.Text;
using FlyballStatTracker.Data.EfCore;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Data.EFCore.Repositories;

namespace Sheridan.Flyball.Tests.Integration
{
    public static class InMemoryDbSetup
    {

        public static FlyballDbContext GetContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<FlyballDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var context = new FlyballDbContext(options);

            context.Database.EnsureCreated();

            return context;
        }

        public static IClubRepository ClubRepository(FlyballDbContext context)
        {
            return new ClubRepository(context);
        }
        public static IPersonRepository PersonRepository(FlyballDbContext context)
        {
            return new PersonRepository(context);
        }
        public static IDogRepository DogRepository(FlyballDbContext context)
        {
            return new DogRepository(context);
        }

    }
}
