using FlyballStatTracker.Data.EfCore;

namespace Sheridan.Flyball.Tests.Integration
{
    public static class SeedData
    {
        public static void PopulateTestData(FlyballDbContext context)
        {   
            context.Clubs.Add(ModelSetup.SetupClubWithPeople());
            context.Clubs.Add(ModelSetup.SetupClubWithNoPeople());


            context.SaveChanges();
        }
    }
}