using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Data.EFCore.Repositories;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Data.EFCore.Tests
{
    public class DogTest
    {

        //TODO: 
        //What if dog has no time was is fastest
        //Test where dog has not ran in that position
        //Add StartTime and Run for total Time
        //Have Multiple Dogs in Start
        //Test for Total Points overall
        //Tests for Points by tournament

        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(Dog dog)
        {
            TestHelper.AddOne_ThenOne(dog, typeof(Dog).Name);

        }

        [Theory]
        [InlineAutoData(4.01,1)]
        public void FastestTimeInStart_GetLowestTimeofRuns(double fastestTime,int dogId)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var context = TestHelper.SetupContext(methodName);

            var dogRepo = new DogRepository(context);
            var tournamentRepo = new TournamentRepository(context);

            var tournament = TestHelper.SetupTournament();
            
            tournamentRepo.Add(tournament);

            var time = dogRepo.FastestTimeInStart(dogId);

            time.ShouldBe(fastestTime);

        }
        
        [Theory]
        [InlineAutoData(5.3, 3)]
        public void FastestTimeInPack_GetLowestTimeofRuns(double fastestTime, int dogId)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var context = TestHelper.SetupContext(methodName);

            var dogRepo = new DogRepository(context);
            var tournamentRepo = new TournamentRepository(context);

            var tournament = TestHelper.SetupTournament();

            tournamentRepo.Add(tournament);

            var time = dogRepo.FastestTimeInPack(dogId);

            time.ShouldBe(fastestTime);

        }
    }
}