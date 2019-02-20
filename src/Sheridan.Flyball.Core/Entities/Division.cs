using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sheridan.Core.Models;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Core.Entities
{
    public class Division : BaseEntityInt
    {
        public Division()
        {
          
        }
        public string Name { get; set; }
        public double? BreakOutTime { get; set; }
        public RacingClass RacingClass { get; set; }
        private readonly List<Team> _teams = new List<Team>();
        public IEnumerable<Team> Teams => new ReadOnlyCollection<Team>(_teams);
        public int TournamentId { get; set; }

        public void AddTeam(Team team)
        {
          
            _teams.Add(team);
        }

        public bool ReRunStart()
        {
            if (Equals(RacingClass, RacingClass.Open) || Equals(RacingClass, RacingClass.Veteran))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}