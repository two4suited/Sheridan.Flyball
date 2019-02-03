using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyballStatTracker.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Sheridan.Data.EntityFramework;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;

namespace Sheridan.Flyball.Data.EFCore.Repositories
{
    public class ClubRepository : RepositoryInt<Club>,IClubRepository
    {
        private readonly FlyballDbContext _dbContext;

        public ClubRepository(FlyballDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        

        public IList<Person> GetPeople(int clubId)
        {
            return _dbContext.Clubs.Include(x => x.People).Single(x => x.Id == clubId).People.ToList();
        }

        public IList<Person> GetPeopleWithDogs(int clubId)
        {
            return _dbContext.Clubs.Include(x => x.People).ThenInclude(x => x.Dogs).Single(x => x.Id == clubId).People.ToList();
        }

        public IList<Dog> GetDogs(int clubId)
        {
            var dogs = from c in _dbContext.Clubs
                join p in _dbContext.People on c.Id equals p.ClubId
                join d in _dbContext.Dogs on p.Id equals d.PersonId
                select d;

            return dogs.ToList();
        }

        public double GetTeamsFastestTime(int clubId)
        {
            var races = _dbContext.Tournaments.Include(x => x.Races).SelectMany(x => x.Races).Where(c => c.Team.Club.Id == clubId);
            var time = races.SelectMany(x => x.Heats).Min(x => x.HeatTime);

            return time;
        }

        
    }
}