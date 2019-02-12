using FlyballStatTracker.Data.EfCore;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Tests.Integration
{
    public static class SeedData
    {
        public static void PopulateTestData(FlyballDbContext context)
        {   
            Sheridan.Flyball.Data.EFCore.SeedData.PopulateData(context);
            context.Clubs.Add(ModelSetup.SetupClubWithPeople());
            context.Clubs.Add(ModelSetup.SetupClubWithNoPeople());


            context.SaveChanges();
        }
    }
}