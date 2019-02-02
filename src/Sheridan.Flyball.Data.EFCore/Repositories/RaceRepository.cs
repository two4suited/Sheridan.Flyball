using Sheridan.Data.EntityFramework;
using System.Collections.Generic;
using FlyballStatTracker.Data.EfCore;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;

namespace Sheridan.Flyball.Data.EFCore.Repositories
{
    public class RaceRepository : Repository<Race>,IRaceRepository
    {
        public RaceRepository(FlyballDbContext dbContext) : base(dbContext)
        {
        }

        public IList<Heat> GetListOfHeats(int raceId)
        {
            throw new System.NotImplementedException();
        }
    }
}