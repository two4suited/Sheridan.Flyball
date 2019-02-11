//using System;
//using Sheridan.Flyball.Core.Entities;
//using Sheridan.Flyball.Core.Interfaces.Repository;
//using Sheridan.Flyball.Core.Interfaces.Services;

//namespace Sheridan.Flyball.Service
//{
//    public class TournamentService : ITournamentService
//    {
//        private readonly ITournamentRepository _tournamentRepository;
//        private readonly IRaceRepository _raceRepository;
//        private readonly ITeamRepository _teamRepository;
//        private readonly IDivisionRepository _divisionRepository;
        

//        public TournamentService(
//            ITournamentRepository tournamentRepository,
//            IRaceRepository raceRepository,
//            ITeamRepository teamRepository,
//            IDivisionRepository divisionRepository)
//        {
//            _tournamentRepository = tournamentRepository;
//            _raceRepository = raceRepository;
//            _teamRepository = teamRepository;
//            _divisionRepository = divisionRepository;
           
//        }

//        public Tournament CreateTournament(Tournament tournament)
//        {
//            return _tournamentRepository.Add(tournament);
//        }

//        public Division CreateDivision(int tournamentId, Division division)
//        {
//            throw new NotImplementedException();
//        }

//        public Race CreateRace(int tournamentId, Race race)
//        {
//            throw new NotImplementedException();
//        }

//        public Heat CreateHeat(int raceId, Heat heat)
//        {
//            throw new NotImplementedException();
//        }

//        public Team CreateTeam(int tournamentId, Team team, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Dog dog5, Dog dog6)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
