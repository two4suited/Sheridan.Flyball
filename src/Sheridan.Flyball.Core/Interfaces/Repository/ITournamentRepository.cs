using System.Collections.Generic;
using Sheridan.Core.Interfaces;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Repository
{
    public interface ITournamentRepository : IRepository<Tournament>
    {
        IList<Division> GetDivisions(int tournamentId);
        IList<Race> GetListOfRacesInOrder(int tournamentId);
        IList<Team> GetListOfTeams(int tournamentId);
        int GetDogsPoints(int tournamentId);
    }
}