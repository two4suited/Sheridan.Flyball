using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FlyballStatTracker.Data.EfCore;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IList<Person>> GetPeople(int clubId)
        {
            return await _context.People.Where(x => x.ClubId == clubId).ToListAsync();
        }

        public async Task<IList<Dog>> GetDogs(int clubId)
        {
            var dogs = from c in _context.Clubs
                       join p in _context.People on c.Id equals p.ClubId
                       join d in _context.Dogs on p.Id equals d.PersonId
                       select d;

            return await dogs.ToListAsync();
        }

        public async Task<Club> Create(CreateClubModel newClub)
        {
            var club = CreateClubModel.ToClub(newClub);
            await _context.Clubs.AddAsync(club);
            await _context.SaveChangesAsync();
            
            return club;
        }

        public async Task<Club> GetById(int id)
        {
            return await _context.Clubs.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Club> Update(UpdateClubModel updateClub)
        {
            var club = await this.GetById(updateClub.Id);

            if (club == null) return null;

            club = UpdateClubModel.ToClub(updateClub, club);
            _context.Clubs.Update(club);
            _context.SaveChanges();
            return club;
        }

        public async Task<IList<Club>> All()
        {
            return await _context.Clubs.ToListAsync();
        }

    }
}
