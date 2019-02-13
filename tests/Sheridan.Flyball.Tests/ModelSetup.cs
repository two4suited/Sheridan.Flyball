using System;
using System.Collections.Generic;
using System.Text;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Tests
{
    public class ModelSetup
    {



        public static Club SetupClubWithNoPeople()
        {
            return new Club()
            {
                Id = 101,
                NafaClubNumber = 20,
                Name = "Rip It Up",
            };
        }

        public static Club SetupClubWithPeople()
        {
            var club =  new Club()
            {
                Id = 100,
                NafaClubNumber = 20,
                Name = "Rip It Up",
            };

            club.AddPerson(ModelSetup.SetupPerson(club.Id,100));

            return club;
        }

        public static Person SetupPerson(int clubId,int id)
        {
            return new Person()
            {
                ClubId = clubId,
                FirstName = "Brian",
                Id = id,
                LastName = "Sheridan"
            };
        }

        public static Dog SetupDog(int personId, int id)
        {
            return new Dog()
            {
                Id = id,
                PersonId = personId,
                NafaCrn = "100083"
            };
        }

        public static RaceYear SetupRaceYear()
        {
            return new RaceYear()
            {
                Id = 100,
                EndDate = new DateTime(DateTime.Today.Year, 10, 31),
                StartDate = new DateTime(DateTime.Now.AddYears(-1).Year, 11, 1)
            };
        }

        public static Tournament SetupTournament()
        {
            var tournament= new Tournament()
            {
               Id= 100,
               StartDate = SetupRaceYear().StartDate.AddMonths(3),
               TournamentNumber = 100
            };
            return tournament;
        }

        public static Division SetupDivision()
        {
            return new Division()
            {
                Id = 100,
                RacingClass = RacingClass.Regular,
                Name = "Regular 1",
                BreakOutTime = 18.00
            };
        }

        public static Team SetupTeam()
        {
            var team = new Team()
            {
                Id = 100,
                SeedTime = 19.00
            };

            return team;
        }

        public static Club RipItUp => new Club() {Id = 100, NafaClubNumber = 100, Name = "RipItUp"};
        public static Person BrianSheridan => new Person() {Id = 100,ClubId = RipItUp.Id, FirstName = "Brian", LastName = "Sheridan"};
        public static Dog Bree => new Dog() {Id = 100, PersonId = BrianSheridan.Id, NafaCrn = "100036"};
        public static Dog Maggie => new Dog() { Id = 101, PersonId = BrianSheridan.Id, NafaCrn = "100037" };
        public static Dog Decibel => new Dog() { Id = 102, PersonId = BrianSheridan.Id, NafaCrn = "100038" };
        public static Dog Lucy => new Dog() { Id = 103, PersonId = BrianSheridan.Id, NafaCrn = "100039" };

        public static RaceYear CurrentRaceYear => new RaceYear()
        {
            Id = 100,
            EndDate = new DateTime(DateTime.Today.Year, 10, 31),
            StartDate = new DateTime(DateTime.Now.AddYears(-1).Year, 11, 1)
        };

        public static Tournament KingsTournament => new Tournament()
            {Id = 100, StartDate = CurrentRaceYear.StartDate.AddMonths(3), TournamentNumber = 100};

        public static Division Regular1 => new Division()
            {Id = 100, BreakOutTime = null, Name = "Regular 1", RacingClass = RacingClass.Regular};

        public static Division Regular2 => new Division()
            { Id = 102, BreakOutTime = 18.00, Name = "Regular 2", RacingClass = RacingClass.Regular };

        public static Division Open1 => new Division()
            { Id = 101, BreakOutTime = null, Name = "Open 1", RacingClass = RacingClass.Open };

        public static Division Open2 => new Division()
            { Id = 104, BreakOutTime = 19.00, Name = "Open 2", RacingClass = RacingClass.Open };



        public static Race Race1LeftSide => new Race() {Id = 100, LaneSide = LaneSide.Left, RaceNumber = 1};

    }
}
