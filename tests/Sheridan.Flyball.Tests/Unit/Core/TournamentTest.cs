using System.Linq;
using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Core
{
    public class TournamentTest
    {

        [Theory, InlineAutoData()]
        public void AddDivision_WhenDivisionAdded_ThenOneDivisin(Division division)
        {
            var tournament = new Tournament();
            tournament.AddDivision(division);

            tournament.Divisions.Count().ShouldBe(1);

        }

        [Theory, InlineAutoData()]
        public void AddTeam_WhenCalled_ThenOneTeam(Team team)
        {
            var tournament = new Tournament();
            tournament.AddTeam(team);

            tournament.Teams.Count().ShouldBe(1);
        }

        [Theory]
        [InlineAutoData()]
        public void AddRace_ThenRaceAdded(Tournament tournament, Race race)
        {
            tournament.Races.ToList().Clear();
            tournament.AddRace(race);

            tournament.Races.Count().ShouldBe(1);
        }
        
    }
}
