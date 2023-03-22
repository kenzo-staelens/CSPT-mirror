using Microsoft.EntityFrameworkCore;
using Models.Results;
using webapi.Entities;

namespace webapi.Repositories {
    public class ResultRepository : IResultRepository {

        private SwimmingClubContext _context;
        public ResultRepository(SwimmingClubContext context) {
            _context = context;
        }
        public async Task<GetResultModel> GetResult(Guid raceid, Guid swimmerid) {
            return await (from r in _context.Results where r.RaceId == raceid && r.SwimmerId == swimmerid select new GetResultModel() {
                RaceId = r.RaceId,
                SwimmerId = r.SwimmerId,
                CurrentPersonalBest = r.CurrentPersonalBest,
                RaceResult = r.RaceResult,
                SwimmerFirstName = r.Swimmer.FirstName,
                SwimmerLastName = r.Swimmer.LastName,
                Schedule = r.Race.Schedule,
                SwimmingPoolName = r.Race.SwimmingPool.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetResultModel>> GetResults() {
            return await (from r in _context.Results select new GetResultModel() {
                RaceId = r.RaceId,
                SwimmerId = r.SwimmerId,
                CurrentPersonalBest = r.CurrentPersonalBest,
                RaceResult = r.RaceResult,
                SwimmerFirstName = r.Swimmer.FirstName,
                SwimmerLastName = r.Swimmer.LastName,
                Schedule = r.Race.Schedule,
                SwimmingPoolName = r.Race.SwimmingPool.Name
            }).ToListAsync();
        }

        public async Task<GetResultModel> PostResult(PostResultModel postResultModel) {
            Result result = new Result {
                SwimmerId = postResultModel.SwimmerId,
                RaceId = postResultModel.RaceId,
                CurrentPersonalBest = postResultModel.CurrentPersonalBest,
                RaceResult = postResultModel.RaceResult,
            };
            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            return await GetResult(postResultModel.RaceId, postResultModel.SwimmerId);
        }
    }
}
