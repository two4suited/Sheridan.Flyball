using Sheridan.Data.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using FlyballStatTracker.Data.EfCore;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Enumerations;
using Sheridan.Flyball.Core.Interfaces.Repository;

namespace Sheridan.Flyball.Data.EFCore.Repositories
{
    public class HeatRepository : RepositoryInt<Heat>,IHeatRepository
    {
        private readonly FlyballDbContext _dbContext;

        public HeatRepository(FlyballDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DogPosition> GetLineup(int heatId)
        {
            return _dbContext.Heats.Single(x => x.Id == heatId).Lineup.Where(x => Position.GetFullRunPositions().Contains(x.Position)).ToList();
            
        }

        public DogRun GetTimeByPosition(Position position, int heatId)
        {
           return _dbContext.Heats.Single(x => x.Id == heatId).DogRuns.First(x => x.Position.Equals(position));
        }

        public List<DogRun> GetListOfTimes(int heatId)
        {
            return _dbContext.Heats.Single(x => x.Id == heatId).DogRuns.ToList();
        }
    }
}