using System.Collections.Generic;
using System.Threading.Tasks;
using Sheridan.Core.Interfaces;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Repository
{
    public interface IPersonRepository : IRepositoryInt<Person>
    {
        Task<IList<Dog>> GetListOfDogs(int personId);
        Task<IList<Person>> GetPeopleOnClub(int clubId);
    }
}