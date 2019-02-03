using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Xunit;

namespace Sheridan.Flyball.Tests.Integration.Data
{
    public class DivisionTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(Division division)
        {
            TestHelper.AddOne_ThenOne(division, typeof(Division).Name);
        }

        //[Theory]
        //[InlineAutoData()]
        //public void GetTeamsInDivision(Tournament tournament)
        //{
        //    var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //    var context = TestHelper.SetupContext(methodName);

        //    var divisionRepo = new DivisionRepository(context);
        //    var tournamentRepo = new TournamentRepository(context);

        //    var division = tournament.Divisions[0];

        //    tournamentRepo.Add(tournament);

        //    var teamsDivisionRepo = divisionRepo.GetTeamsInDivision(division.Id);

        //    var teamsDivision = tournament.Divisions.Single(x => x.Id == division.Id).Teams;

        //    teamsDivision.Count().ShouldBe(teamsDivisionRepo.Count());

        //}
    }
}