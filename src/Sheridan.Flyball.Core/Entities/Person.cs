using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sheridan.Core.Models;

namespace Sheridan.Flyball.Core.Entities
{
    public class Person : BaseEntityInt
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private readonly List<Dog> _dogs = new List<Dog>();
        public IEnumerable<Dog> Dogs => new ReadOnlyCollection<Dog>(_dogs);

        public int ClubId { get; set; }
        public void AddDog(Dog dog)
        {
           _dogs.Add(dog);
        }

 
    }
}