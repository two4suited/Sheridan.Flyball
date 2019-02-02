using System.Collections.Generic;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Core.Interfaces.Services;

namespace Sheridan.Flyball.Service
{
    public class RaceYearService : IRaceYearService
    {
        private readonly IRaceYearRepository _raceYearRepository;

        public RaceYearService(IRaceYearRepository raceYearRepository)
        {
            _raceYearRepository = raceYearRepository;
        }
        public RaceYear CreateRaceYear(RaceYear raceYear)
        {
            throw new System.NotImplementedException();
        }

        public RaceYear CreateRaceYear(int startYear, int endYear)
        {
            var raceyear=  new RaceYear(startYear,endYear);
            return _raceYearRepository.Add(raceyear);
        }

        public IList<RaceYear> GetRaceYears()
        {
            return _raceYearRepository.List();
        }

        public RaceYear GetRaceYearById(int id)
        {
            return null// _raceYearRepository.(id);
        }
    }
}