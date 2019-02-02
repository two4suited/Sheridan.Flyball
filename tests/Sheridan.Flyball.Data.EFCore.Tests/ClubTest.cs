using System.Collections.Generic;
using System.Linq;
using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Data.EFCore.Repositories;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Data.EFCore.Tests
{
    public class ClubTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(Club club)
        {
            TestHelper.AddOne_ThenOne(club,typeof(Club).Name);
        }

        

        [Theory]
        [InlineAutoData()]
        public void GetPerson_ThenReturnRightNumberOfPeople(Club club)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            var repo = new ClubRepository(TestHelper.SetupContext(methodName));

            repo.Add(club);

            var people = repo.GetPeople(club.Id);

            people.Count.ShouldBe(club.People.Count);
        }

        [Theory]
        [InlineAutoData()]
        public void GetPeopleWithDogs_ThenReturnRightNumberOfDogs(Club club)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            var repo = new ClubRepository(TestHelper.SetupContext(methodName));

            repo.Add(club);

            var people = repo.GetPeopleWithDogs(club.Id);

            var totalDogs = club.People.SelectMany(x => x.Dogs).Count();
            var totalDogsDb = people.SelectMany(x => x.Dogs).Count();

            totalDogsDb.ShouldBe(totalDogs);
            

        }

        [Theory]
        [InlineAutoData()]
        public void GetDogs_NumberOfDogsInModel_MatchesDatabase(Club club)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var repo = new ClubRepository(TestHelper.SetupContext(methodName));

            repo.Add(club);

            var dogsRepo = repo.GetDogs(club.Id);

            var dogs = club.People.SelectMany(x => x.Dogs);

            dogsRepo.Count.ShouldBe(dogs.Count());
            
        }

        [Fact]
        public void GetFastestTime_SetupTournament_GetFastestTime()
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var context = TestHelper.SetupContext(methodName);


            var repoTournament = new TournamentRepository(context);
            var repoClub = new ClubRepository(context);

            var tournament = TestHelper.SetupTournament();
            repoTournament.Add(tournament);
            

            var tournaments = new List<Tournament> {tournament};

            var randomClubId = tournaments.SelectMany(x => x.Teams).Select(x => x.Club).First().Id;
            tournaments[0].Races[0].Team.Club.Id = randomClubId;
            var repoTime = repoClub.GetTeamsFastestTime(randomClubId);
            
            var races = tournaments.SelectMany(x => x.Races).Where(c => c.Team.Club.Id == randomClubId);
            var time = races.SelectMany(x => x.Heats).Min(x => x.HeatTime);

            time.ShouldBe(repoTime);

        }




    }
}