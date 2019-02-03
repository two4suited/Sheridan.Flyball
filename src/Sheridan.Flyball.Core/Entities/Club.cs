using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sheridan.Core.Models;

namespace Sheridan.Flyball.Core.Entities
{
    public class Club : BaseEntityInt
    {
        private readonly List<Person> _people = new List<Person>();
        public IEnumerable<Person> People => new ReadOnlyCollection<Person>(_people);

        
        public int NafaClubNumber { get; set; }
        public string Name { get; set; }
        
        public void AddPerson(Person person)
        {
            _people.Add(person);
        }

       
    }
}