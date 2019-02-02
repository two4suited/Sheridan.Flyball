using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Core.Interfaces.Services;

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

        public Club CreateClub(Club club)
        {
            return _clubRepository.Add(club);
        }

        public Person CreatePerson(int clubId, Person person)
        {
            person.ClubId = clubId;

            return _personRepository.Add(person);
        }

        public Dog CreateDog(int personId, Dog dog)
        {
            dog.PersonId = personId;

            return _dogRepository.Add(dog);
        }
    }
}
