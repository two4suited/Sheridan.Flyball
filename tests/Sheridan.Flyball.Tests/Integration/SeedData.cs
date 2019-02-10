using FlyballStatTracker.Data.EfCore;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Tests.Integration
{
    public static class SeedData
    {
        public static void PopulateTestData(FlyballDbContext context)
        {
            context.Clubs.Add(ModelSetup.SetupClub());

            context.SaveChanges();
        }
    }
}