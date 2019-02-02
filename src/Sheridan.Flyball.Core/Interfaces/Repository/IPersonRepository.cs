using System.Collections.Generic;
using Sheridan.Core.Interfaces;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Repository
{
    public interface IPersonRepository : IRepositoryInt<Person>
    {
        IList<Dog> GetListOfDogs(int personId);
    }
}