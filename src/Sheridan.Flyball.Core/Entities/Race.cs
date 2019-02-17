using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sheridan.Core.Models;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Core.Entities
{
    public class Race: BaseEntityInt
    {
        public Race(){
           
        }

        public int RaceNumber { get; set; }
        public LaneSide LaneSide { get; set; }
        private readonly List<Heat> _heats = new List<Heat>();
        public IEnumerable<Heat> Heats => new ReadOnlyCollection<Heat>(_heats);
        public Team Team { get; set; }
        public int TournamentId { get; set; }


        public override string ToString()
        {
            return $"{RaceNumber}-{LaneSide.Name}";
        }

        public void AddHeat(Heat heat)
        {
            heat.RaceId = this.Id;
            _heats.Add(heat);
        }

    }
}