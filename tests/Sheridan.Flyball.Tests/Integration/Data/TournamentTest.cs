//using System.Linq;
//using AutoFixture.Xunit2;
//using FlyballStatTracker.Data.EfCore;
//using Microsoft.EntityFrameworkCore;
//using Sheridan.Flyball.Core.Entities;
//using Shouldly;
//using Xunit;

//namespace Sheridan.Flyball.Tests.Integration.Data
//{
//    public class TournamentTest
//    {
        
//        [Theory]
//        [InlineAutoData()]
//        public void AddOne_ThenOne(Tournament tournament)
//        {
//            TestHelper.AddOne_ThenOne(tournament, typeof(Tournament).Name);
//        }

//        [Theory]
//        [InlineData(1)]
//        public void SetTournamentNumber_ThenTournamentNumber(int tournamentNumber)
//        {
//            var options = new DbContextOptionsBuilder<FlyballDbContext>()
//                .UseInMemoryDatabase(databaseName: "set_tournament_number")
//                .Options;

//            var tournament = new Tournament()
//            {
//                TournamentNumber = tournamentNumber
//            };

//            using (var context = new FlyballDbContext(options))
//            {
//                context.Tournaments.Add(tournament);
//                context.SaveChanges();
//            }

//            // Use a separate instance of the context to verify correct data was saved to database
//            using (var context = new FlyballDbContext(options))
//            {
//                context.Tournaments.Single().TournamentNumber.ShouldBe(tournamentNumber);
//                context.Tournaments.Single().Teams.Count.ShouldBe(0);
//            }
//        }

//        //[Theory]
//        //[InlineAutoData()]
//        //public void GetListofTeams_ShouldReturnSameAmount(Tournament tournament)
//        //{
//        //    var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
//        //    var context = TestHelper.SetupContext(methodName);
            
//        //    var tournamentRepo = new TournamentRepository(context);
            
//        //    tournamentRepo.Add(tournament);

//        //    var teams = tournament.Teams;
//        //    var teamsRepo = tournamentRepo.GetListOfTeams(tournament.Id);

//        //    teams.Count.ShouldBe(teamsRepo.Count);
//        //}

//        //[Theory]
//        //[InlineAutoData()]
//        //public void GetListOfDivisions_ShouldReturnSameAmount(Tournament tournament)
//        //{
//        //    var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
//        //    var context = TestHelper.SetupContext(methodName);

//        //    var tournamentRepo = new TournamentRepository(context);

//        //    tournamentRepo.Add(tournament);

//        //    var division = tournament.Divisions;
//        //    var divisionRepo = tournamentRepo.GetDivisions(tournament.Id);

//        //    division.Count.ShouldBe(divisionRepo.Count);
//        //}

//    }
//}