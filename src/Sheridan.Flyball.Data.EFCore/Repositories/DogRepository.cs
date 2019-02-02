using System.Collections.Generic;
using System.Linq;
using FlyballStatTracker.Data.EfCore;
using Sheridan.Data.EntityFramework;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Enumerations;
using Sheridan.Flyball.Core.Interfaces.Repository;

namespace Sheridan.Flyball.Data.EFCore.Repositories
{
    public class DogRepository : Repository<Dog>,IDogRepository
    {
        private readonly FlyballDbContext _dbContext;

        public DogRepository(FlyballDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public double FastestTimeInStart(int dogId)
        {
            var time = _dbContext.DogRuns.Where(x => x.Dog.Id == dogId).Where(x => Equals(x.Position, Position.First)).Min(x => x.Time);
            return time;
        }

        public double FastestTimeInPack(int dogId)
        {
            var time = _dbContext.DogRuns.Where(x =>
                (Equals(x.Position, Position.Second) || Equals(x.Position, Position.Third) ||
                Equals(x.Position, Position.Fourth)) && x.Dog.Id == dogId).Where(x => x.Dog.Id == dogId).Min(x => x.Time);

            return time;
        }

        public int GetTotalPoints(int dogId)
        {
            throw new System.NotImplementedException();
        }

        public List<dynamic> GetPointsByTournament(int dogId)
        {
            throw new System.NotImplementedException();
        }

        public double FastestTimeInStartWithStartTime(int dogId)
        {
            throw new System.NotImplementedException();
        }
    }
}