using FlyballStatTracker.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Tests.Integration
{
    public class InMemoryDbSetup
    {
        public FlyballDbContext Context;
        public InMemoryDbSetup(string dbName)
        {
            var options = new DbContextOptionsBuilder<FlyballDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            Context = new FlyballDbContext(options);

            Context.Database.EnsureCreated();
        }



      

        public Club SetupClub()
        {
            return new Club()
            {
                Id = 1,
                NafaClubNumber = 20,
                Name = "Rip It Up",
            };
        }

        public Person SetupPerson(int clubId)
        {
            return new Person()
            {
                ClubId = clubId,
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName"
            };
        }
    }
}
