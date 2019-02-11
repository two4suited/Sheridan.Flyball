//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Sheridan.Flyball.Core.Entities;
//using Sheridan.Flyball.Core.Interfaces.Repository;
//using Sheridan.Flyball.Core.Interfaces.Services;
//using Sheridan.Flyball.Core.ViewModels.Create;
//using Sheridan.Flyball.Core.ViewModels.Update;

//namespace Sheridan.Flyball.Service
//{
//    public class PersonService : IPersonService
//    {
//        private readonly IClubRepository _clubRepository;
//        private readonly IPersonRepository _personRepository;


//        public PersonService(
//            IClubRepository clubRepository,
//            IPersonRepository personRepository)
//        {
//            _clubRepository = clubRepository;
//            _personRepository = personRepository;
//        }

//        public async Task<Person> Create(CreatePersonModel newPerson)
//        {
//            var club = await _clubRepository.GetByIdAsync(newPerson.ClubId);

//            if (club == null) return null;

//            var person = CreatePersonModel.ToPerson(newPerson);

//            club.AddPerson(person);

//            await _clubRepository.UpdateAndSaveAsync(club);

//            return person;
//        }

//        public async Task<Person> GetById(int id)
//        {
//            throw new System.NotImplementedException();
//        }

//        public async Task<Person> Update(UpdatePersonModel club)
//        {
//            throw new System.NotImplementedException();
//        }

//        public async Task<IList<Person>> All()
//        {
//            throw new System.NotImplementedException();
//        }

//        public async Task<IList<Dog>> GetDogs(int personId)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}