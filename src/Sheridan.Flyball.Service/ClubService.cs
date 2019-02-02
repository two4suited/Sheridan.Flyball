using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Core.Interfaces.Services;
using Sheridan.Flyball.Core.ViewModels.Create;

namespace Sheridan.Flyball.Service
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IDogRepository _dogRepository;

        public ClubService(
            IClubRepository clubRepository,
            IPersonRepository personRepository,
            IDogRepository dogRepository)
        {
            _clubRepository = clubRepository;
            _personRepository = personRepository;
            _dogRepository = dogRepository;
        }


        public Club CreateClub(CreateClubModel club)
        {
            throw new System.NotImplementedException();
        }

        public Person CreatePerson(CreatePersonModel person)
        {
            throw new System.NotImplementedException();
        }

        public Dog CreateDog(CreateDogModel dog)
        {
            throw new System.NotImplementedException();
        }
    }
}
