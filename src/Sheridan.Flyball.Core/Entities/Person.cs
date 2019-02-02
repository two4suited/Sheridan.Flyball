using System.Collections.Generic;
using Sheridan.Core.Models;

namespace Sheridan.Flyball.Core.Entities
{
    public class Person : BaseEntityInt
    {
        public Person()
        {
            Dogs = new List<Dog>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Dog> Dogs { get; set; }

        public int ClubId { get; set; }
        public void AddDog(Dog dog)
        {
           Dogs.Add(dog);
        }

 
    }
}