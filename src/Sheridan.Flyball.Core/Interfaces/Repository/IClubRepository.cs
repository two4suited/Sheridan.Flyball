using System.Collections.Generic;
using System.Threading.Tasks;
using Sheridan.Core.Interfaces;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Repository
{
    public interface IClubRepository : IRepositoryInt<Club>
    {
       
        Task<IList<Person>> GetPeople(int clubId);
        Task<IList<Dog>> GetDogs(int clubId);
        double GetTeamsFastestTime(int clubId);
    }
}