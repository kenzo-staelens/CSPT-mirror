using Models.SwimmingPools;
using System.Security.Cryptography.Xml;
using webapi.Entities;

namespace webapi.Repositories {
    public class SwimmingPoolRepository : ISwimmingPoolRepository {
        private SwimmingClubContext _context;
        public SwimmingPoolRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetSwimmingPoolModel> GetSwimmingPool(Guid id) {
            GetSwimmingPoolModel swimmingpool = new();
            return swimmingpool;
            throw new NotImplementedException();
        }

        public async Task<List<GetSwimmingPoolModel>> GetSwimmingPools() {
            List<GetSwimmingPoolModel> swimmingpools = new();
            return swimmingpools;
            throw new NotImplementedException();
        }

        public async Task<GetSwimmingPoolModel> PostSwimmingPool(PostSwimmingPoolModel postSwimmingPoolModel) {
            GetSwimmingPoolModel swimmingpool = new();
            return swimmingpool;
            throw new NotImplementedException();
        }
    }
}
