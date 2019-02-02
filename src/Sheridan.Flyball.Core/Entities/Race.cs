using System.Collections.Generic;
using Sheridan.Core.Models;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Core.Entities
{
    public class Race: BaseEntityInt
    {
        public Race()
        {
            Heats = new List<Heat>();
        }

        public int RaceNumber { get; set; }
        public LaneSide LaneSide { get; set; }
        public IList<Heat> Heats { get; set; }
        public Team Team { get; set; }


        public override string ToString()
        {
            return $"{RaceNumber}-{LaneSide.Name}";
        }

        public void AddHeat(Heat heat)
        {
            Heats.Add(heat);
        }

    }
}