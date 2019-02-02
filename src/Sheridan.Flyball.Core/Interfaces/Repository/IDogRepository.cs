using System.Collections.Generic;
using Sheridan.Core.Interfaces;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Repository
{
    public interface IDogRepository : IRepositoryInt<Dog>
    {
        double FastestTimeInStart(int dogId);
        double FastestTimeInPack(int dogId);
        int GetTotalPoints(int dogId);
        List<dynamic> GetPointsByTournament(int dogId);
        double FastestTimeInStartWithStartTime(int dogId);
    }
}