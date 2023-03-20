using Models.Swimmers;
using webapi.Entities;

namespace webapi.Repositories {
    public class SwimmerRepository : ISwimmerRepository {

        private SwimmingClubContext _context;
        public SwimmerRepository(SwimmingClubContext context) {
            _context = context;
        }
        public async Task<GetSwimmerModel> GetSwimmer(Guid id) {
            GetSwimmerModel swimmer = new();
            return swimmer;
            throw new NotImplementedException();
        }

        public async Task<List<GetSwimmerModel>> GetSwimmers() {
            List<GetSwimmerModel> swimmers = new();
            return swimmers;
            throw new NotImplementedException();
        }

        public async Task<GetSwimmerModel> PostSwimmer(PostSwimmerModel postSwimmerModel) {
            GetSwimmerModel swimmer = new();
            return swimmer;
            throw new NotImplementedException();
        }
    }
}
