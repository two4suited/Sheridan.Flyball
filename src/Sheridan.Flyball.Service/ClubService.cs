using System.ComponentModel;
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


        public Club CreateClub(CreateClubModel newClub)
        {
            var club = new Club() {NafaClubNumber = newClub.NafaClubNumber, Name = newClub.Name};

            return _clubRepository.AddAndSave(club);
        }

        public Person CreatePerson(CreatePersonModel newPerson)
        {
            var person = new Person()
                {ClubId = newPerson.ClubId, LastName = newPerson.FirstName, FirstName = newPerson.LastName};

            return _personRepository.AddAndSave(person);
        }

        public Dog CreateDog(CreateDogModel dog)
        {
            throw new System.NotImplementedException();
        }
    }
}
