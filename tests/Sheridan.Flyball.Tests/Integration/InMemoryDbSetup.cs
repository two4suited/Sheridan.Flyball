using FlyballStatTracker.Data.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Data.EFCore.Repositories;

namespace Sheridan.Flyball.Tests.Integration
{
    public class InMemoryDbSetup
    {
        private readonly FlyballDbContext _context;
        public InMemoryDbSetup(string dbName)
        {
            var options = new DbContextOptionsBuilder<FlyballDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            _context = new FlyballDbContext(options);

            
        }

        public IClubRepository ClubRepository()
        {
            return new ClubRepository(_context);
        }
        public IPersonRepository PersonRepository()
        {
            return new PersonRepository(_context);
        }
        public IDogRepository DogRepository()
        {
            return new DogRepository(_context);
        }
    }
}
