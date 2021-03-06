﻿using System;
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
        public static Dog BrianDog5 => new Dog() { Id = 104, PersonId = BrianSheridan.Id, NafaCrn = "100040" };
        public static Dog BrianDog6 => new Dog() { Id = 105, PersonId = BrianSheridan.Id, NafaCrn = "100041" };


        public static Club TestClub => new Club() {Id = 101, Name = "Test Club", NafaClubNumber = 101};

        public static Person DonaldTrump => new Person()
            {Id = 101, ClubId = TestClub.Id, FirstName = "Donald", LastName = "Trump"};

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
            {Id = 100, StartDate = CurrentRaceYear.StartDate.AddMonths(3), TournamentNumber = 100};

        public static Division Regular1 => new Division()
            {Id = 100, BreakOutTime = null, Name = "Regular 1", RacingClass = RacingClass.Regular};

        public static Division Regular2 => new Division()
            { Id = 102, BreakOutTime = 18.00, Name = "Regular 2", RacingClass = RacingClass.Regular };

        public static Division Open1 => new Division()
            { Id = 101, BreakOutTime = null, Name = "Open 1", RacingClass = RacingClass.Open };

        public static Division Open2 => new Division()
            { Id = 104, BreakOutTime = 19.00, Name = "Open 2", RacingClass = RacingClass.Open };

        public static Team Team1 => new Team() {Id = 100, SeedTime = 16.00};
        public static Team Team2 => new Team() {Id = 101, SeedTime = 19.5};
        public static Team Team3 => new Team() { Id = 102, SeedTime = 17.00 };
        public static Team Team4 => new Team() { Id = 103, SeedTime = 21.5 };

        public static Heat Heat1 => new Heat() {Id = 100, HeatNumber = 1, HeatTime = 16.5, Outcome = Outcome.Win};

        public static Race Race1LeftSide => new Race() {Id = 100, LaneSide = LaneSide.Left, RaceNumber = 1};
        public static Race Race1RightSide => new Race() { Id = 101, LaneSide = LaneSide.Right, RaceNumber = 1 };

    }
}
