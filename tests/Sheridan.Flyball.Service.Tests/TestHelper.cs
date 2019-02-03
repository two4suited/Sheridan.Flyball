using System;
using System.Collections.Generic;
using System.Text;
using FlyballStatTracker.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Data.EFCore.Repositories;

namespace Sheridan.Flyball.Service.Tests
{
   public class TestHelper
   {
       private readonly FlyballDbContext _context;
        public TestHelper(string dbName)
        {
            var options = new DbContextOptionsBuilder<FlyballDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            _context = new FlyballDbContext(options);
        }

        public static FlyballDbContext SetupContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<FlyballDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var context = new FlyballDbContext(options);

            return context;
        }

        public  IClubRepository SetupClubRepository()
        {
            return new ClubRepository(_context);
        }
        public  IPersonRepository SetupPersonRepository()
        {
            return new PersonRepository(_context);
        }
        public  IDogRepository SetupDogRepository()
        {
            return new DogRepository(_context);
        }
    }
}
