using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sheridan.Core.Models;

namespace Sheridan.Flyball.Core.Entities
{
    public class Tournament : BaseEntityInt
    {

        public DateTime StartDate { get; set; }
        public int TournamentNumber { get; set; }

        private RaceYear _raceYear;
        public RaceYear RaceYear => _raceYear;

        private readonly List<Division> _divisions = new List<Division>();
        public IEnumerable<Division> Divisions => new ReadOnlyCollection<Division>(_divisions);

        private readonly List<Team> _teams = new List<Team>();
        public IEnumerable<Team> Teams => new ReadOnlyCollection<Team>(_teams);

        private readonly List<Race> _races = new List<Race>();
        public IEnumerable<Race> Races => new ReadOnlyCollection<Race>(_races);

        public void AddTeam(Team team)
        {
            _teams.Add(team);
        }

        public void AddRaceYear(RaceYear raceYear)
        {
            _raceYear = raceYear;
        }
        
        public void AddRace(Race race)
        {
            _races.Add(race);
        }

        public void AddDivision(Division division)
        {
            _divisions.Add(division);
        }
    }
}