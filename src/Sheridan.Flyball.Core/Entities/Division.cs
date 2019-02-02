using System.Collections.Generic;
using Sheridan.Core.Models;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Core.Entities
{
    public class Division : BaseEntityInt
    {
        public Division()
        {
           Teams = new List<Team>();
        }
        public string Name { get; set; }
        public double? BreakOutTime { get; set; }
        public RacingClass RacingClass { get; set; }
        public List<Team> Teams { get; set; }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
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