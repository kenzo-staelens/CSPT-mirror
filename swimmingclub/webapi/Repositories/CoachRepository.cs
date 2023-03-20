using Models.Coaches;
using webapi.Entities;

namespace webapi.Repositories {
    public class CoachRepository : ICoachRepository {

        private SwimmingClubContext _context;
        public CoachRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetCoachModel> GetCoach(Guid id) {
            GetCoachModel coach = new();
            return coach;
            throw new NotImplementedException();
        }

        public async Task<List<GetCoachModel>> GetCoaches() {
            List<GetCoachModel> coaches = new();
            return coaches;
            throw new NotImplementedException();
        }

        public async Task<GetCoachModel> PostCoach(PostCoachModel postCoachModel) {
            GetCoachModel coach = new();
            return coach;
            throw new NotImplementedException();
        }
    }
}
