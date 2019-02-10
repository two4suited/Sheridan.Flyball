using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Core.Interfaces.Services;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.Core.ViewModels.Update;

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

        public async Task<IList<Person>> GetPeople(int clubId)
        {
            return await _clubRepository.GetPeople(clubId);
        }

        public async Task<IList<Dog>> GetDogs(int clubId)
        {
            return await _clubRepository.GetDogs(clubId);
        }

        public async Task<Club> Create(CreateClubModel newClub)
        {
            var club = CreateClubModel.ToClub(newClub);

            return await _clubRepository.AddAndSaveAsync(club);
        }

        public async Task<Club> GetById(int id)
        {
            return await _clubRepository.GetByIdAsync(id);
        }

        public async Task<Club> Update(UpdateClubModel updateClub)
        {
            var club = await _clubRepository.GetByIdAsync(updateClub.Id);

            if (club == null) return null;

            club = UpdateClubModel.ToClub(updateClub,club);
            return await _clubRepository.UpdateAndSaveAsync(club);
        }

        public async Task<IList<Club>> All()
        {
            return await _clubRepository.ListAsync();
        }
    }
}
