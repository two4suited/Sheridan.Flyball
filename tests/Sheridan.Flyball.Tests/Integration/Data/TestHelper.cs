//using System;
//using System.Collections.Generic;
//using System.Linq;
//using FlyballStatTracker.Data.EfCore;
//using Microsoft.EntityFrameworkCore;
//using Sheridan.Flyball.Core.Entities;
//using Sheridan.Flyball.Core.Enumerations;
//using Shouldly;

//namespace Sheridan.Flyball.Tests.Integration.Data
//{
//    public class TestHelper
//    {
//        public static void AddOne_ThenOne<T>(T value, string dbName) where T : class
//        {
//            var options = new DbContextOptionsBuilder<FlyballDbContext>()
//                .UseInMemoryDatabase(databaseName: dbName)
//                .Options;

//            using (var context = new FlyballDbContext(options))
//            {
//                context.Set<T>().Add(value);
//                context.SaveChanges();
//            }

//            // Use a separate instance of the context to verify correct data was saved to database
//            using (var context = new FlyballDbContext(options))
//            {
//                context.Set<T>().Count().ShouldBe(1);
//            }
            
//        }
//        public static FlyballDbContext SetupContext(string dbName)
//        {
//            var options = new DbContextOptionsBuilder<FlyballDbContext>()
//                .UseInMemoryDatabase(databaseName: dbName)
//                .Options;

//            var context = new FlyballDbContext(options);

//            return context;
//        }

//        public static Club SetupClub()
//        {
//            return new Club()
//            {
//                Id = 1,
//                NafaClubNumber = 20,
//                Name = "Rip It Up",
//            };
//        }

//        public static Person SetupPerson(int clubId)
//        {
//            var person = new Person()
//            {
//                Id = 1,
//                ClubId = clubId,
//                FirstName = RandomString(),
//                LastName = RandomString()
//            };
//            return person;
//        }

//        public static Dog SetupDog(int personId)
//        {
//            return new Dog()
//            {
//                Id = 1,
//                NafaCrn = "1",
//                PersonId = personId
//            };
//        }

//        public static string RandomString()
//        {

//            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
//            var random = new Random();
//            var list = Enumerable.Repeat(0, 8).Select(x => chars[random.Next(chars.Length)]);
//            return string.Join("", list);
//        }

        

//        public static List<DogRun> SetupDogRun(DogRun[] dogRuns)
//        {
//            var runs = new List<DogRun>();
//            foreach (var dogRun in dogRuns)
//            {
//                runs.Add(dogRun);
//            }

//            return runs;
//        }

       

//        public static Tournament SetupTournament()
//        {
//            var club = SetupClub();
//            var brian = SetupPerson(club.Id);
         
//            club.AddPerson(brian);

//            var bree = new Dog()
//            {
//                Id = 1,
//                PersonId = brian.Id,
//                NafaCrn = "23"
//            };

//            var decibel = new Dog()
//            {
//                Id = 2,
//                PersonId = brian.Id,
//                NafaCrn = "2"
//            };

//            var lucy = new Dog()
//            {
//                Id = 3,
//                PersonId = brian.Id,
//                NafaCrn = "3"
//            };
//            var maggie = new Dog()
//            {
//                Id = 4,
//                PersonId = 4,
//                NafaCrn = "4"
//            };

//            brian.AddDog(decibel);
//            brian.AddDog(bree);
//            brian.AddDog(lucy);
//            brian.AddDog(maggie);

//            var tournament = new Tournament()
//            {
//                Id = 1,
//                StartDate = DateTime.Now,
//                TournamentNumber = 2
               
//            };

//            var raceyear = new RaceYear()
//            {
//                Id = 1,
//                StartDate = DateTime.Now,
//                EndDate = DateTime.Now
//            };

//            var team = new Team()
//            {
//                Club = club,
//                Id = 1,
//                SeedTime = 17.0
//            };
//            team.AddDog(bree);
//            team.AddDog(decibel);
//            team.AddDog(lucy);
//            team.AddDog(maggie);

//            tournament.RaceYear = raceyear;

//            var open1 = new Division()
//            {
//                Id = 1,
//                Name = "Open1",
//                RacingClass = RacingClass.Open,
//                BreakOutTime = 18
//            };
//            tournament.AddDivision(open1);
//            open1.AddTeam(team);

           

//            tournament.AddTeam(team);


//            var startDog = new DogPosition()
//            {
//                Dog = bree,
//                Id = 1,
//                Position = Position.First
//            };
//            var secondDog = new DogPosition()
//            {
//                Dog = lucy,
//                Id = 2,
//                Position = Position.Second
//            };
//            var thirdDog = new DogPosition()
//            {
//                Dog = maggie,
//                Id = 3,
//                Position = Position.Third
//            };
//            var anchorDog = new DogPosition()
//            {
//                Id = 4,
//                Dog = decibel,
//                Position = Position.Fourth
//            };



//            var heat1 = new Heat()
//            {Id = 1,HeatNumber = 1};
//            heat1.AddDogToLineup(open1,bree,lucy,maggie,decibel);
//            heat1.AddResult(20,Outcome.Lose);
//            heat1.AddStartTime(bree,.011,null, open1);
//            heat1.AddTime(bree,Position.First,4.01,null, open1);
//            heat1.AddTime(lucy,Position.Second, 5.3,null, open1);
//            heat1.AddTime(maggie,Position.Third,4.10,null, open1);
//            heat1.AddTime(decibel,Position.Fourth, 3.61,null, open1);

//            var heat2 = new Heat()
//            { Id = 2, HeatNumber = 2 };
//            heat2.AddDogToLineup(open1,bree, lucy, maggie, decibel);
//            heat2.AddResult(18.45, Outcome.Win);
//            heat2.AddStartTime(bree, .101, null,open1);
//            heat2.AddTime(bree, Position.First, 4.11,null , open1);
//            heat2.AddTime(lucy, Position.Second, 5.3, null, open1);
//            heat2.AddTime(maggie, Position.Third, 4.23, null,open1);
//            heat2.AddTime(decibel, Position.Fourth, 3.81, null,open1);

//            var heat3 = new Heat()
//            { Id = 3, HeatNumber = 3 };
//            heat3.AddDogToLineup(open1,bree, lucy, maggie, decibel);
//            heat3.AddResult(16.45, Outcome.Win);
//            heat3.AddStartTime(bree, .131, null,open1);
//            heat3.AddTime(bree, Position.First, 4.143, null, open1);
//            heat3.AddTime(lucy, Position.Second, 5.323, null, open1);
//            heat3.AddTime(maggie, Position.Third, 4.233, null, open1);
//            heat3.AddTime(decibel, Position.Fourth, 3.817, null, open1);

//            var heat4 = new Heat()
//            { Id = 4, HeatNumber = 4};
//            heat4.AddDogToLineup(open1,bree, lucy, maggie, decibel);
//            heat4.AddResult(17.95, Outcome.Win);
//            heat4.AddStartTime(bree, .231, null, open1);
//            heat4.AddTime(bree, Position.First, 4.091, null, open1);
//            heat4.AddTime(lucy, Position.Second, 5.321, null, open1);
//            heat4.AddTime(maggie, Position.Third, 4.231, null, open1);
//            heat4.AddTime(decibel, Position.Fourth, 3.812, null, open1);


//            var race1 = new Race()
//            {
//                Id = 1,
//                LaneSide = LaneSide.Left,
//                Team = team,
//                RaceNumber = 1
               
//            };
//            race1.AddHeat(heat1);
//            race1.AddHeat(heat2);
//            race1.AddHeat(heat3);
//            race1.AddHeat(heat4);

//            tournament.AddRace(race1);

//            return tournament;


//        }


//    }
//}