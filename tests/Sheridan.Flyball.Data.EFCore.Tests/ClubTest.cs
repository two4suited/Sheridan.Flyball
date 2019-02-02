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


        [Fact]
        public void GetPerson_ThenReturnRightNumberOfPeople()
        {
            int numberOfPeople = 3;

            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            var repo = new ClubRepository(TestHelper.SetupContext(methodName));

            var club = TestHelper.SetupClub();

            for (int i = 1; i <= numberOfPeople; i++)
            {
                var p1 = new Person() { ClubId = club.Id, Id = i, FirstName = TestHelper.RandomString(), LastName = TestHelper.RandomString() };
                club.AddPerson(p1);
            }

            repo.AddAndSave(club);

            repo.GetPeople(club.Id).Count.ShouldBe(numberOfPeople);
            

        }

        [Fact]
        public void GetDogs_NumberOfDogsInModel_MatchesDatabase()
        {
            int numberOfDogs = 8;

            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var repo = new ClubRepository(TestHelper.SetupContext(methodName));

            var club = TestHelper.SetupClub();

            var p1 =  new Person(){ClubId = club.Id,Id = 1,FirstName = TestHelper.RandomString(),LastName = TestHelper.RandomString()};
            var p2 = new Person() { ClubId = club.Id, Id = 2, FirstName = TestHelper.RandomString(), LastName = TestHelper.RandomString() };

            for (int i = 1; i <= numberOfDogs; i++)
            {
                if (i % 2 == 0)
                {
                    Dog d = new Dog() {Id = i, PersonId = p1.Id, NafaCrn = i.ToString()};
                    p1.AddDog(d);
                }
                else
                {
                    Dog d = new Dog() { Id = i, PersonId = p2.Id, NafaCrn = i.ToString() };
                    p2.AddDog(d);
                }
            }
        
            club.AddPerson(p1);
            club.AddPerson(p2);

            repo.AddAndSave(club);
            

            var dogsRepo = repo.GetDogs(club.Id);

            

            dogsRepo.Count.ShouldBe(numberOfDogs);
            
        }

        //[Fact]
        //public void GetFastestTime_SetupTournament_GetFastestTime()
        //{
        //    var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    var context = TestHelper.SetupContext(methodName);


        //    var repoTournament = new TournamentRepository(context);
        //    var repoClub = new ClubRepository(context);

        //    var tournament = TestHelper.SetupTournament();
        //    repoTournament.AddAndSave(tournament);
            

        //    var tournaments = new List<Tournament> {tournament};

        //    var randomClubId = tournaments.SelectMany(x => x.Teams).Select(x => x.Club).First().Id;
        //    tournaments[0].Races[0].Team.Club.Id = randomClubId;
        //    var repoTime = repoClub.GetTeamsFastestTime(randomClubId);
            
        //    var races = tournaments.SelectMany(x => x.Races).Where(c => c.Team.Club.Id == randomClubId);
        //    var time = races.SelectMany(x => x.Heats).Min(x => x.HeatTime);

        //    time.ShouldBe(repoTime);

        //}




    }
}