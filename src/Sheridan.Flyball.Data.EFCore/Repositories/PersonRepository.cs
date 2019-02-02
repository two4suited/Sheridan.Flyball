using Sheridan.Data.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using FlyballStatTracker.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;

namespace Sheridan.Flyball.Data.EFCore.Repositories
{
    public class PersonRepository : Repository<Person>,IPersonRepository
    {
        private readonly FlyballDbContext _dbContext;

        public PersonRepository(FlyballDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Dog> GetListOfDogs(int personId)
        {
            return _dbContext.People.Include(x => x.Dogs).Single(x => x.Id == personId).Dogs.ToList();
        }
    }
}