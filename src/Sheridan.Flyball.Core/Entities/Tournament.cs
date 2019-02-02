using System;
using System.Collections.Generic;
using Sheridan.Core.Models;

namespace Sheridan.Flyball.Core.Entities
{
    public class Tournament : BaseEntityInt
    {
        public Tournament()
        {
            Teams = new List<Team>();
            Divisions = new List<Division>();
            Races = new List<Race>();
        }

        public DateTime StartDate { get; set; }
        public int TournamentNumber { get; set; }
        public RaceYear RaceYear { get; set; }
        
   
        public IList<Division> Divisions { get; set; }
        public IList<Team> Teams { get; set; }
        public IList<Race> Races { get; set; }


        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }
        
        public void AddRace(Race race)
        {
            Races.Add(race);
        }

        public void AddDivision(Division division)
        {
            Divisions.Add(division);
        }
    }
}