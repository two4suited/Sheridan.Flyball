using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.ViewModels.Create;

namespace Sheridan.Flyball.Core.Interfaces.Services
{
    public interface IClubService
    {
        Club CreateClub(CreateClubModel club);
        Person CreatePerson(CreatePersonModel person);
        Dog CreateDog(CreateDogModel dog);

    }
}