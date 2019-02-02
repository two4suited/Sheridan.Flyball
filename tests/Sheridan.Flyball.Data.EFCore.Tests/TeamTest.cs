using System.Linq;
using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Data.EFCore.Repositories;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Data.EFCore.Tests
{
    public class TeamTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(Team team)
        {
            TestHelper.AddOne_ThenOne(team, typeof(Team).Name);

        }

        [Theory]
        [InlineAutoData()]
        public void GetListOfDogs_NumberOfDogsShouldMatch(Team team)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var context = TestHelper.SetupContext(methodName);

            var teamRepo = new TeamRepository(context);

            teamRepo.Add(team);

            var dogs = team.Dogs;
            var dogsRepo = teamRepo.GetListOfDogs(team.Id);

            dogs.Count.ShouldBe(dogsRepo.Count);
        }

        [Theory]
        [InlineAutoData()]
        public void GetListOfRaces_RacesShouldMatch(Tournament tournament)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var context = TestHelper.SetupContext(methodName);

            var teamRepo = new TeamRepository(context);
            var tournamentRepo = new TournamentRepository(context);


            tournamentRepo.Add(tournament);
            var teamid = tournament.Teams[0].Id;

            var races = tournament.Races.Where(x => x.Team.Id == teamid).ToList();

            
            var racesRepo = teamRepo.GetListOfRaces(teamid);

            races.Count.ShouldBe(racesRepo.Count);
        }
    }
}