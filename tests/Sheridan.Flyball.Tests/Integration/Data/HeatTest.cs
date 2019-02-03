using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Xunit;

namespace Sheridan.Flyball.Tests.Integration.Data
{
    public class HeatTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(Heat heat)
        {
            TestHelper.AddOne_ThenOne(heat, typeof(Heat).Name);
        }

        //[Fact]
        //public void GetLineup_ReturnRightNumberofDogs()
        //{
        //    var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    var context = TestHelper.SetupContext(methodName);

        //    var heatRepo = new HeatRepository(context);
        //    var tournamentRepo = new TournamentRepository(context);

        //    var tournament = TestHelper.SetupTournament();
        //    tournamentRepo.Add(tournament);

        //    var heatid = tournament.Races[0].Heats[0].Id;

        //    var lineup = tournament.Races.SelectMany(x => x.Heats).Single(x => x.Id == heatid).Lineup.Where(x => Position.GetFullRunPositions().Contains(x.Position));
        //    var lineupRepo = heatRepo.GetLineup(heatid);

        //    lineup.Count().ShouldBe(lineupRepo.Count);

        //}

        //[Fact]
        //public void GetTimeByPosition_ReturnRightTime()
        //{
        //    var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    var context = TestHelper.SetupContext(methodName);

        //    var heatRepo = new HeatRepository(context);
        //    var tournamentRepo = new TournamentRepository(context);

        //    var tournament = TestHelper.SetupTournament();
        //    tournamentRepo.Add(tournament);

        //    var heatid = tournament.Races[0].Heats[0].Id;
        //    var postion = Position.Second;

        //    var run = tournament.Races.SelectMany(x => x.Heats).Single(x => x.Id == heatid).DogRuns.First(x => x.Position.Equals(postion));

        //    var runRepo = heatRepo.GetTimeByPosition(postion, heatid);

        //    run.Time.ShouldBe(runRepo.Time);

        //}
        //[Fact]
        //public void GetListofTimes_TimesMatch()
        //{
        //    var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    var context = TestHelper.SetupContext(methodName);

        //    var heatRepo = new HeatRepository(context);
        //    var tournamentRepo = new TournamentRepository(context);

        //    var tournament = TestHelper.SetupTournament();
        //    tournamentRepo.Add(tournament);

        //    var heatid = tournament.Races[0].Heats[0].Id;

        //    var runs = tournament.Races.SelectMany(x => x.Heats).Single(x => x.Id == heatid).DogRuns;

        //    var runsRepo = heatRepo.GetListOfTimes(heatid);

        //    runs[0].Time.ShouldBe(runsRepo[0].Time);
        //    runs[1].Time.ShouldBe(runsRepo[1].Time);
        //    runs[2].Time.ShouldBe(runsRepo[2].Time);
        //    runs[3].Time.ShouldBe(runsRepo[3].Time);
        //}
    }
}