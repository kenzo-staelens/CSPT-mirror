using Models.Races;
using System.Diagnostics;
using webapi.Entities;

namespace webapi.Repositories {
    public class RaceRepository : IRaceRepository {

        private SwimmingClubContext _context;
        public RaceRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetRaceModel> GetRace(Guid id) {
            GetRaceModel race = new();
            return race;
            throw new NotImplementedException();
        }

        public async Task<List<GetRaceModel>> GetRaces() {
            List<GetRaceModel> races = new();
            return races;
            throw new NotImplementedException();
        }

        public async Task<GetRaceModel> PostRace(PostRaceModel postRaceModel) {
            GetRaceModel race = new();
            return race;
            throw new NotImplementedException();
        }
    }
}
