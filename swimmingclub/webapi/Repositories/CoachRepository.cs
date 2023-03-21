using Models.Coaches;
using webapi.Entities;

namespace webapi.Repositories {
    public class CoachRepository : ICoachRepository {

        private SwimmingClubContext _context;
        public CoachRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetCoachModel> GetCoach(Guid id) {
            return (from r in _context.Coaches where r.Id == id select new GetCoachModel() {
                FirstName = r.FirstName,
                LastName = r.LastName,
                DateOfBirth = r.DateOfBirth,
                Level = r.Level,
                Gender = r.Gender
            }).FirstOrDefault();
            
        }

        public async Task<List<GetCoachModel>> GetCoaches() {
            return (from r in _context.Coaches select new GetCoachModel() { }).ToList();
        }

        public async Task<GetCoachModel> PostCoach(PostCoachModel postCoachModel) {
            GetCoachModel coach = new() { FirstName = "abcdef" };
            return coach;
        }
    }
}
