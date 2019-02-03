using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.ViewModels.Create
{
    public class CreatePersonModel
    {
        public int ClubId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static Person ToPerson(CreatePersonModel newPerson)
        {
            return new Person()
                { ClubId = newPerson.ClubId, LastName = newPerson.FirstName, FirstName = newPerson.LastName };
        }
    }
}
