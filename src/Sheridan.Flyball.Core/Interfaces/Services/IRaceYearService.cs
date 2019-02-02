using System.Collections.Generic;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Services
{
    public interface IRaceYearService
    {
        RaceYear CreateRaceYear(RaceYear raceYear);
        RaceYear CreateRaceYear(int startYear, int endYear);
        IList<RaceYear> GetRaceYears();
        RaceYear GetRaceYearById(int id);
    }
}