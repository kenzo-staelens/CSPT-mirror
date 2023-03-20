using Models.Results;
using webapi.Entities;

namespace webapi.Repositories {
    public class ResultRepository : IResultRepository {

        private SwimmingClubContext _context;
        public ResultRepository(SwimmingClubContext context) {
            _context = context;
        }
        public async Task<GetResultModel> GetResult(Guid id) {
            GetResultModel result = new();
            return result;
            throw new NotImplementedException();
        }

        public async Task<List<GetResultModel>> GetResults() {
            List<GetResultModel> results = new();
            return results;
            throw new NotImplementedException();
        }

        public async Task<GetResultModel> PostResult(PostResultModel postResultModel) {
            GetResultModel result = new();
            return result;
            throw new NotImplementedException();
        }
    }
}
