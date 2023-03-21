using Models.Swimmers;
using webapi.Entities;

namespace webapi.Repositories {
    public class SwimmerRepository : ISwimmerRepository {

        private SwimmingClubContext _context;
        public SwimmerRepository(SwimmingClubContext context) {
            _context = context;
        }
        public async Task<GetSwimmerModel> GetSwimmer(Guid id) {
            return (from r in _context.Swimmers where r.Id == id select new GetSwimmerModel() {
                FirstName = r.FirstName,
                LastName = r.LastName,
                DateOfBirth = r.DateOfBirth,
                Gender = r.Gender,
                FinalPoints = r.FinalPoints
            })
            .FirstOrDefault();

            
        }

        public async Task<List<GetSwimmerModel>> GetSwimmers() {
            return (from r in _context.Swimmers select new GetSwimmerModel() {
                FirstName = r.FirstName,
                LastName = r.LastName,
                DateOfBirth = r.DateOfBirth,
                Gender = r.Gender,
                FinalPoints = r.FinalPoints
            }).ToList();
        }

        public async Task<GetSwimmerModel> PostSwimmer(PostSwimmerModel postSwimmerModel) {
            GetSwimmerModel swimmer = new();
            return swimmer;
        }
    }
}
