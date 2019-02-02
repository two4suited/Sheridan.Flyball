using System.Collections.Generic;
using Sheridan.Core.Interfaces;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Repository
{
    public interface ITeamRepository : IRepositoryInt<Team>
    {
        IList<Dog> GetListOfDogs(int teamId);
        IList<Race> GetListOfRaces(int teamId);
        IList<int> GetListOfDogPoints(int teamId);
    }
}