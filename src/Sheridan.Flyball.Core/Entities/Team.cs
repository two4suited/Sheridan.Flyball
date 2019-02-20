using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Sheridan.Core.Models;

namespace Sheridan.Flyball.Core.Entities
{
    public class Team : BaseEntityInt
    {
        public double SeedTime { get; set; }
        private readonly List<Dog> _dogs = new List<Dog>();
        public IEnumerable<Dog> Dogs => new ReadOnlyCollection<Dog>(_dogs);
        public int DivisionId { get; set; }
        public int TournamentId { get; set; }

        private Club _club;
        public Club Club => _club;
      
        public void AddClub(Club club)
        {
            _club = club;
        }
        
        public void AddDog(Dog dog)
        {
            _dogs.Add(dog);
        }
        
    }
}