//using System;
//using System.Collections.Generic;
//using System.Text;
//using FlyballStatTracker.Data.EfCore;
//using Sheridan.Flyball.Core.Interfaces.Repository;
//using Sheridan.Flyball.Data.EFCore.Repositories;

//namespace Sheridan.Flyball.Tests.Integration.Data
//{
//    public class DatabaseFixture : IDisposable
//    {

//        public FlyballDbContext Context;

//        public DatabaseFixture()
//        {
//            var db = new InMemoryDbSetup("ClubTests");
//            SeedData.PopulateTestData(db.Context);
//            Context = db.Context;
//        }
//        public void Dispose()
//        {
//           Context.Dispose();
//        }

//        public IClubRepository ClubRepository()
//        {
//            return new ClubRepository(Context);
//        }
//        public IPersonRepository PersonRepository()
//        {
//            return new PersonRepository(Context);
//        }
//        public IDogRepository DogRepository()
//        {
//            return new DogRepository(Context);
//        }
//    }
//}
