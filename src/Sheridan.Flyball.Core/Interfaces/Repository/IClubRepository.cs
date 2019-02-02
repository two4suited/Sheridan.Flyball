using System.Collections.Generic;
using Sheridan.Core.Interfaces;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Repository
{
    public interface IClubRepository : IRepository<Club>
    {
       
        IList<Person> GetPeople(int clubId);
        IList<Person> GetPeopleWithDogs(int clubId);
        IList<Dog> GetDogs(int clubId);
        double GetTeamsFastestTime(int clubId);
    }
}