using System.Collections.Generic;
using Sheridan.Core.Interfaces;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Repository
{
    public interface IDivisionRepository : IRepositoryInt<Division>
    {
        IList<Team> GetTeamsInDivision(int divisionId);
    }
}