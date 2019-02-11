using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FlyballStatTracker.Data.EfCore;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Services;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.Core.ViewModels.Update;

namespace Sheridan.Flyball.Service
{
    public class ClubService : IClubService
    {
        private readonly FlyballDbContext _context;


        public ClubService(FlyballDbContext context)
        {
            _context = context;
        }

        //public async Task<IList<Person>> GetPeople(int clubId)
        //{
            

        //    return await _personRepository.GetPeopleOnClub(clubId);
        //}

        //public async Task<IList<Dog>> GetDogs(int clubId)
        //{
        //    return await _clubRepository.GetDogs(clubId);
        //}

        //public async Task<Club> Create(CreateClubModel newClub)
        //{
        //    var club = CreateClubModel.ToClub(newClub);

        //    return await _clubRepository.AddAndSaveAsync(club);
        //}

        //public async Task<Club> GetById(int id)
        //{
        //    return await _clubRepository.GetByIdAsync(id);
        //}

        //public async Task<Club> Update(UpdateClubModel updateClub)
        //{
        //    var club = await _clubRepository.GetByIdAsync(updateClub.Id);

        //    if (club == null) return null;

        //    club = UpdateClubModel.ToClub(updateClub,club);
        //    return await _clubRepository.UpdateAndSaveAsync(club);
        //}

        //public async Task<IList<Club>> All()
        //{
        //    return await _clubRepository.ListAsync();
        //}
        public async Task<Club> Create(CreateClubModel newModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Club> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Club> Update(UpdateClubModel updateModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Club>> All()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Person>> GetPeople(int clubId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Dog>> GetDogs(int clubId)
        {
            throw new System.NotImplementedException();
        }
    }
}
