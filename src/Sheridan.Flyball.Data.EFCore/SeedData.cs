using System;
using System.Linq;
using FlyballStatTracker.Data.EfCore;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Data.EFCore
{
    public class SeedData
    {
        public static void PopulateData(FlyballDbContext context,bool IsDevelopment)
        {
            RacingClassPopulate(context);
            FaultPopulate(context);
            LaneSidePopulate(context);
            PositionPopulate(context);
            OutcomePopulate(context);

            if(IsDevelopment)
            {
                DevelopmentData(context);
            }
            
            context.SaveChanges();
        }


        public static Club RipItUp => new Club() { NafaClubNumber = 987, Name = "RipItUp" };
        public static Person BrianSheridan => new Person() { ClubId = RipItUp.Id, FirstName = "Brian", LastName = "Sheridan" };
        public static Dog Bree => new Dog() { PersonId = BrianSheridan.Id, NafaCrn = "100036" };
        public static Dog Maggie => new Dog() { Id = 101, PersonId = BrianSheridan.Id, NafaCrn = "100037" };
        public static Dog Decibel => new Dog() { Id = 102, PersonId = BrianSheridan.Id, NafaCrn = "100038" };
        public static Dog Lucy => new Dog() { Id = 103, PersonId = BrianSheridan.Id, NafaCrn = "100039" };
        public static Dog BrianDog5 => new Dog() { Id = 104, PersonId = BrianSheridan.Id, NafaCrn = "100040" };
        public static Dog BrianDog6 => new Dog() { Id = 105, PersonId = BrianSheridan.Id, NafaCrn = "100041" };


        public static Club TestClub => new Club() { Id = 101, Name = "Test Club", NafaClubNumber = 101 };

        public static Person DonaldTrump => new Person()
        { Id = 101, ClubId = TestClub.Id, FirstName = "Donald", LastName = "Trump" };

        public static Dog Snoopy => new Dog() { Id = 200, PersonId = DonaldTrump.Id, NafaCrn = "100000" };
        public static Dog Pluto => new Dog() { Id = 201, PersonId = DonaldTrump.Id, NafaCrn = "100001" };
        public static Dog Jack => new Dog() { Id = 202, PersonId = DonaldTrump.Id, NafaCrn = "100002" };
        public static Dog Lassie => new Dog() { Id = 203, PersonId = DonaldTrump.Id, NafaCrn = "100003" };
        public static Dog DonaldDog5 => new Dog() { Id = 204, PersonId = DonaldTrump.Id, NafaCrn = "100004" };
        public static Dog DonaldDog6 => new Dog() { Id = 205, PersonId = DonaldTrump.Id, NafaCrn = "100005" };

        public static RaceYear CurrentRaceYear => new RaceYear()
        {
            Id = 100,
            EndDate = new DateTime(DateTime.Today.Year, 10, 31),
            StartDate = new DateTime(DateTime.Now.AddYears(-1).Year, 11, 1)
        };

        public static Tournament KingsTournament => new Tournament()
        { Id = 100, StartDate = CurrentRaceYear.StartDate.AddMonths(3), TournamentNumber = 100 };

        public static Division Regular1 => new Division()
        { Id = 100, BreakOutTime = null, Name = "Regular 1", RacingClass = RacingClass.Regular };

        public static Division Regular2 => new Division()
        { Id = 102, BreakOutTime = 18.00, Name = "Regular 2", RacingClass = RacingClass.Regular };

        public static Division Open1 => new Division()
        { Id = 101, BreakOutTime = null, Name = "Open 1", RacingClass = RacingClass.Open };

        public static Division Open2 => new Division()
        { Id = 104, BreakOutTime = 19.00, Name = "Open 2", RacingClass = RacingClass.Open };

        public static Team Team1 => new Team() { Id = 100, SeedTime = 16.00 };
        public static Team Team2 => new Team() { Id = 101, SeedTime = 19.5 };
        public static Team Team3 => new Team() { Id = 102, SeedTime = 17.00 };
        public static Team Team4 => new Team() { Id = 103, SeedTime = 21.5 };

        public static Heat Heat1 => new Heat() { Id = 100, HeatNumber = 1, HeatTime = 16.5, Outcome = Outcome.Win };

        public static Race Race1LeftSide => new Race() { Id = 100, LaneSide = LaneSide.Left, RaceNumber = 1 };
        public static Race Race1RightSide => new Race() { Id = 101, LaneSide = LaneSide.Right, RaceNumber = 1 };

        private static void DevelopmentData(FlyballDbContext context)
        {
            var ripItUp = context.Clubs.FirstOrDefault(x => x.NafaClubNumber == 987);
            if(ripItUp == null) context.Clubs.Add(RipItUp);
        }

        private static void RacingClassPopulate(FlyballDbContext context)
        {
            foreach (var racingClass in RacingClass.List())
            {
                var val = context.RacingClasses.FirstOrDefault(x => x.Name == racingClass.Name);
                if (val == null)
                {
                    context.RacingClasses.Add(racingClass);
                }
            }
        }

      

        private static void FaultPopulate(FlyballDbContext context)
        {
            foreach (var fault in Fault.List())
            {
                var val = context.Faults.FirstOrDefault(x => x.Name == fault.Name);
                if (val == null)
                {
                    context.Faults.Add(fault);
                }
            }
        }

        private static void LaneSidePopulate(FlyballDbContext context)
        {
            foreach (var lane in LaneSide.List())
            {
                var val = context.Lane.FirstOrDefault(x => x.Name == lane.Name);
                if (val == null)
                {
                    context.Lane.Add(lane);
                }
            }
        }

        private static void PositionPopulate(FlyballDbContext context)
        {
            foreach (var position in Position.List())
            {
                var val = context.Positions.FirstOrDefault(x => x.Name == position.Name);
                if (val == null)
                {
                    context.Positions.Add(position);
                }
            }
        }

        private static void OutcomePopulate(FlyballDbContext context)
        {
            foreach (var outcome in Outcome.List())
            {
                var val = context.Outcomes.FirstOrDefault(x => x.Name == outcome.Name);
                if (val == null)
                {
                    context.Outcomes.Add(outcome);
                }
            }
        }

    }
}