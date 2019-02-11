//using System.Collections.Generic;
//using System.Linq;
//using FlyballStatTracker.Data.EfCore;
//using Microsoft.EntityFrameworkCore;
//using Sheridan.Data.EntityFramework;
//using Sheridan.Flyball.Core.Entities;
//using Sheridan.Flyball.Core.Interfaces.Repository;

//namespace Sheridan.Flyball.Data.EFCore.Repositories
//{
//    public class DivisionRepository : RepositoryInt<Division>, IDivisionRepository
//    {
//        private readonly FlyballDbContext _dbContext;

//        public DivisionRepository(FlyballDbContext dbContext) : base(dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public IList<Team> GetTeamsInDivision(int divisionId)
//        {
//            return _dbContext.Divisions.Include(x => x.Teams).Single(x => x.Id == divisionId).Teams;
//        }
//    }
//}