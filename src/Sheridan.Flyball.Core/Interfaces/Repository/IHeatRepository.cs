using System.Collections.Generic;
using Sheridan.Core.Interfaces;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Core.Interfaces.Repository
{
    public interface IHeatRepository : IRepositoryInt<Heat>
    {
        List<DogPosition> GetLineup(int heatId);
        DogRun GetTimeByPosition(Position position, int heatId);
        List<DogRun> GetListOfTimes(int heatId);
    }
}