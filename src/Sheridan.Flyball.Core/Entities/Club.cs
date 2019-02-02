using System.Collections.Generic;
using Sheridan.Core.Models;

namespace Sheridan.Flyball.Core.Entities
{
    public class Club : BaseEntityInt
    {
        public Club()
        {
            People = new List<Person>();
            
        }
        public int NafaClubNumber { get; set; }
        public string Name { get; set; }
        public IList<Person> People { get; set; }
        
       
        public void AddPerson(Person person)
        {
            People.Add(person);
        }

       
    }
}