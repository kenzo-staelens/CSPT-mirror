using Models.Results;
using webapi.Entities;

namespace webapi.Repositories {
    public class ResultRepository : IResultRepository {

        private SwimmingClubContext _context;
        public ResultRepository(SwimmingClubContext context) {
            _context = context;
        }
        public async Task<GetResultModel> GetResult(Guid raceid, Guid swimmerid) {
            return (from r in _context.Results where r.RaceId == raceid && r.SwimmerId == swimmerid select new GetResultModel() {
                CurrentPersonalBest = r.CurrentPersonalBest,
                RaceResult = r.RaceResult,
                SwimmerFirstName= r.Swimmer.FirstName,
                SwimmerLastName = r.Swimmer.LastName,
                Schedule = r.Race.Schedule,
                SwimmingPoolName = r.Race.SwimmingPool.Name
            }).FirstOrDefault();
        }

        public async Task<List<GetResultModel>> GetResults() {
            return (from r in _context.Results select new GetResultModel() {
                CurrentPersonalBest = r.CurrentPersonalBest,
                RaceResult = r.RaceResult,
                SwimmerFirstName = r.Swimmer.FirstName,
                SwimmerLastName = r.Swimmer.LastName,
                Schedule = r.Race.Schedule,
                SwimmingPoolName = r.Race.SwimmingPool.Name
            }).ToList();
        }

        public async Task<GetResultModel> PostResult(PostResultModel postResultModel) {
            GetResultModel result = new();
            return result;
        }
    }
}
