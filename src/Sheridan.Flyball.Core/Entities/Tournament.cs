using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public IEnumerable<Race> Races => _races.ToList();

        public void AddTeam(Team team)
        {
            team.TournamentId = this.Id;
            _teams.Add(team);
        }

        public void AddRaceYear(RaceYear raceYear)
        {
            _raceYear = raceYear;
        }
        
        public void AddRace(Race race)
        {
            race.TournamentId = this.Id;
            _races.Add(race);
        }

        public void AddDivision(Division division)
        {
            division.TournamentId = this.Id;
            _divisions.Add(division);
        }
    }
}