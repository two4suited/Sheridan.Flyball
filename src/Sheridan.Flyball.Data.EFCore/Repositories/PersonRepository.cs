using Sheridan.Data.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyballStatTracker.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;

namespace Sheridan.Flyball.Data.EFCore.Repositories
{
    public class PersonRepository : RepositoryInt<Person>,IPersonRepository
    {
        private readonly FlyballDbContext _dbContext;

        public PersonRepository(FlyballDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Dog>> GetListOfDogs(int personId)
        {
            var t = await _dbContext.People.Include(x => x.Dogs).SingleAsync(x => x.Id == personId);
            return t.Dogs;
        }

        public async Task<IList<Person>> GetPeopleOnClub(int clubId)
        {
            return await _dbContext.People.Where(x => x.ClubId == clubId).ToListAsync();
        }
    }
}