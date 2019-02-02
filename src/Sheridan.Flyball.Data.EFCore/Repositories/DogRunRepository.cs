using FlyballStatTracker.Data.EfCore;
using Sheridan.Data.EntityFramework;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;

namespace Sheridan.Flyball.Data.EFCore.Repositories
{
    public class DogRunRepository : Repository<DogRun>, IDogRunRepository
    {
        private readonly FlyballDbContext _dbContext;

        public DogRunRepository(FlyballDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}