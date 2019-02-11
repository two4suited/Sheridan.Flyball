using System;
using System.Collections.Generic;
using System.Text;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Tests
{
    public class ModelSetup
    {
        public static Club SetupClubWithNoPeople()
        {
            return new Club()
            {
                Id = 101,
                NafaClubNumber = 20,
                Name = "Rip It Up",
            };
        }

        public static Club SetupClubWithPeople()
        {
            var club =  new Club()
            {
                Id = 100,
                NafaClubNumber = 20,
                Name = "Rip It Up",
            };

            club.AddPerson(ModelSetup.SetupPerson(club.Id));

            return club;
        }

        public static Club SetupClubWithPeopleAndDog()
        {
            var club = new Club()
            {
                Id = 102,
                NafaClubNumber = 20,
                Name = "Rip It Up",
            };
            var person = ModelSetup.SetupPerson(club.Id);
            club.AddPerson(person);

            var dog = ModelSetup.SetupDog(person.Id);
            person.AddDog(dog);

            return club;

        }

        public static Person SetupPerson(int clubId)
        {
            return new Person()
            {
                ClubId = clubId,
                FirstName = "Test",
                Id = 100,
                LastName = "TestLastName"
            };
        }

        public static Dog SetupDog(int personId)
        {
            return new Dog()
            {
                Id = 100,
                NafaCrn = "0",
                PersonId = personId
            };
        }

        
    }
}
