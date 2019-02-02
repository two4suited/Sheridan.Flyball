using FlyballStatTracker.Data.EfCore;
using Sheridan.Data.EntityFramework;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;

namespace Sheridan.Flyball.Data.EFCore.Repositories
{
    public class DogPositionRepository : RepositoryInt<DogPosition>, IDogPositionRepository
    {
        private readonly FlyballDbContext _dbContext;

        public DogPositionRepository(FlyballDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}