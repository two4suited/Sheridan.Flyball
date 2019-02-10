using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.Core.ViewModels.Update;

namespace Sheridan.Flyball.Core.Interfaces.Services
{
    public interface IPersonService : IFlyballService<Person,CreatePersonModel,UpdatePersonModel>
    {
        Task<IList<Dog>> GetDogs(int personId);
    }
}