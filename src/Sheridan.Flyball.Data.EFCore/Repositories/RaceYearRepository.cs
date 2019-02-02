using System.Collections.Generic;
using FlyballStatTracker.Data.EfCore;
using Sheridan.Data.EntityFramework;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;

namespace Sheridan.Flyball.Data.EFCore.Repositories
{
    public class RaceYearRepository : RepositoryInt<RaceYear>,IRaceYearRepository
    {
        private readonly FlyballDbContext _dbContext;

        public RaceYearRepository(FlyballDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Tournament> GetListOfTournaments(string raceYear)
        {
            throw new System.NotImplementedException();
        }
    }
}