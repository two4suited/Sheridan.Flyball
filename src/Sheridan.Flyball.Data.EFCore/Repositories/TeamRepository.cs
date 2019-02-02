using System.Collections.Generic;
using System.Linq;
using FlyballStatTracker.Data.EfCore;
using Sheridan.Data.EntityFramework;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;

namespace Sheridan.Flyball.Data.EFCore.Repositories
{
    public class TeamRepository : Repository<Team>,ITeamRepository
    {
        private readonly FlyballDbContext _dbContext;

        public TeamRepository(FlyballDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Dog> GetListOfDogs(int teamId)
        {
            return _dbContext.Teams.Single(x => x.Id==teamId).Dogs;
        }

        public IList<Race> GetListOfRaces(int teamId)
        {
            return _dbContext.Races.Where(x => x.Team.Id == teamId).ToList();
        }

        public IList<int> GetListOfDogPoints(int teamId)
        {
            throw new System.NotImplementedException();
        }
    }
}