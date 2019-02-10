using FlyballStatTracker.Data.EfCore;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Tests.Integration
{
    public static class SeedData
    {
        public static void PopulateTestData(FlyballDbContext context)
        {
            var club = ModelSetup.SetupClub();
            var person = ModelSetup.SetupPerson(club.Id);

            context.Clubs.Add(club);
            context.People.Add(person);

            context.SaveChanges();
        }
    }
}