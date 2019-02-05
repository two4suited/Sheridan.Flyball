using System.ComponentModel;
using System.Threading.Tasks;
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


        public async Task<Club> CreateClub(CreateClubModel newClub)
        {
            var club = CreateClubModel.ToClub(newClub);

            return await _clubRepository.AddAndSaveAsync(club);
        }

        public async Task<Club> CreatePerson(CreatePersonModel newPerson)
        {
            var club = _clubRepository.GetById(newPerson.ClubId);

            if (club == null) return null;

            var person = CreatePersonModel.ToPerson(newPerson);

            club.AddPerson(person);

            return await _clubRepository.UpdateAndSaveAsync(club);
        }

        public async Task<Person> CreateDog(CreateDogModel dog)
        {
            throw new System.NotImplementedException();
        }
    }
}
