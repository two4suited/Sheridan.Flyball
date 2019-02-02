using System.Collections.Generic;
using Sheridan.Core.Models;

namespace Sheridan.Flyball.Core.Entities
{
    public class Team : BaseEntityInt
    {
        public Team()
        {
            Dogs = new List<Dog>();
        }
       
        public double SeedTime { get; set; }
        public IList<Dog> Dogs { get; set; }
        public Club Club { get; set; }
        
        public void AddDog(Dog dog)
        {
            Dogs.Add(dog);
        }
        
    }
}