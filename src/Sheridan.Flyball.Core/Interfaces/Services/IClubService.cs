using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.ViewModels.Create;

namespace Sheridan.Flyball.Core.Interfaces.Services
{
    public interface IClubService
    {
        Club CreateClub(CreateClubModel club);
        Club CreatePerson(CreatePersonModel person);
        Person CreateDog(CreateDogModel dog);

    }
}