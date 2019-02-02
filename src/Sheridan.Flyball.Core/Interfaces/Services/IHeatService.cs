using System.Collections.Generic;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Core.Interfaces.Services
{
    public interface IHeatService
    {
        List<DogPosition> SetLineup(int heatId,Division division, Dog dog1, Dog dog2, Dog dog3, Dog dog4);
        Heat RunHeat(int heatid, double time, Outcome outcome, params DogRun[] dogRuns);
    }
}