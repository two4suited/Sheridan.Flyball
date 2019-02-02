using System.Collections.Generic;
using Sheridan.Core.Interfaces;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Repository
{
    public interface IRaceYearRepository : IRepositoryInt<RaceYear>
    {
        IList<Tournament> GetListOfTournaments(string raceYear);
    }
}