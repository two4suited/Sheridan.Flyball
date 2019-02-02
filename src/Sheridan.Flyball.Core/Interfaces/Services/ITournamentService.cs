using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Services
{
    public interface ITournamentService
    {
        Tournament CreateTournament(Tournament tournament);
        Division CreateDivision(int tournamentId, Division division);
        Race CreateRace(int tournamentId, Race race);
        Heat CreateHeat(int raceId, Heat heat);
        Team CreateTeam(int tournamentId, Team team,Dog dog1,Dog dog2,Dog dog3,Dog dog4,Dog dog5,Dog dog6);
    }
}
