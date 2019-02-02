using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.Interfaces.Services
{
    public interface IClubService
    {
        Club CreateClub(Club club);
        Person CreatePerson(int clubId, Person person);
        Dog CreateDog(int personId, Dog dog);

    }
}