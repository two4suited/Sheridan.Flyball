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

            var tournament = ModelSetup.KingsTournament;
            tournament.AddDivision(ModelSetup.Open1);
            tournament.AddDivision(ModelSetup.Open2);
            tournament.AddDivision(ModelSetup.Regular1);
            tournament.AddDivision(ModelSetup.Regular2);
            tournament.AddRaceYear(ModelSetup.CurrentRaceYear);

            tournament.AddRace(ModelSetup.Race1LeftSide);
            tournament.AddRace(ModelSetup.Race1RightSide);




            context.SaveChanges();
        }
    }
}