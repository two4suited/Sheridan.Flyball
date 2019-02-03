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
            IDogRepository dogRepository
          )
        {
            _clubRepository = clubRepository;
            _personRepository = personRepository;
            _dogRepository = dogRepository;
        }


        public Club CreateClub(CreateClubModel newClub)
        {
            var club = CreateClubModel.ToClub(newClub);

            return _clubRepository.AddAndSave(club);
        }

        public Club CreatePerson(CreatePersonModel newPerson)
        {
            var club = _clubRepository.GetById(newPerson.ClubId);
            var person = CreatePersonModel.ToPerson(newPerson);

            club.AddPerson(person);

            return _clubRepository.UpdateAndSave(club);
        }

        public Person CreateDog(CreateDogModel dog)
        {
            throw new System.NotImplementedException();
        }
    }
}
