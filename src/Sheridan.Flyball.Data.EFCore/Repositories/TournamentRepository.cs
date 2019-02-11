//using System.Collections.Generic;
//using System.Linq;
//using FlyballStatTracker.Data.EfCore;
//using Sheridan.Data.EntityFramework;
//using Sheridan.Flyball.Core.Entities;
//using Sheridan.Flyball.Core.Interfaces.Repository;

//namespace Sheridan.Flyball.Data.EFCore.Repositories
//{
//    public class TournamentRepository : RepositoryInt<Tournament>,ITournamentRepository
//    {
//        private readonly FlyballDbContext _dbContext;

//        public TournamentRepository(FlyballDbContext dbContext) : base(dbContext)
//        {
//            _dbContext = dbContext;
//        }


//        public IList<Division> GetDivisions(int tournamentId)
//        {
//            return _dbContext.Tournaments.Single(x => x.Id == tournamentId).Divisions;
//        }

//        public IList<Race> GetListOfRacesInOrder(int tournamentId)
//        {
//            throw new System.NotImplementedException();
//        }

//        public IList<Team> GetListOfTeams(int tournamentId)
//        {
//            return _dbContext.Tournaments.Single(x => x.Id == tournamentId).Teams;
//        }

//        public int GetDogsPoints(int tournamentId)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}