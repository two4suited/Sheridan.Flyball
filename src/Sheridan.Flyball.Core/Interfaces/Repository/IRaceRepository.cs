using System.Collections.Generic;
using Sheridan.Core.Interfaces;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Repository
{
    public interface IRaceRepository : IRepositoryInt<Race>
    {
        IList<Heat> GetListOfHeats(int raceId);
    }



    
}