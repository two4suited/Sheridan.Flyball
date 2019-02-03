using System.Threading.Tasks;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.ViewModels.Create;

namespace Sheridan.Flyball.Core.Interfaces.Services
{
    public interface IClubService
    {
        Task<Club> CreateClub(CreateClubModel club);
        Task<Club> CreatePerson(CreatePersonModel person);
        Task<Person> CreateDog(CreateDogModel dog);

    }
}