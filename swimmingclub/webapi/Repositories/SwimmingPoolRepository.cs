using Microsoft.EntityFrameworkCore;
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
            return await (from r in _context.SwimmingPools where r.Id == id select new GetSwimmingPoolModel() {
                Id = r.Id,
                Name = r.Name,
                Street = r.Street,
                City = r.City,
                LaneLength = r.LaneLength,
                ZipCode = r.ZipCode
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetSwimmingPoolModel>> GetSwimmingPools() {
            return await (from r in _context.SwimmingPools select new GetSwimmingPoolModel() {
                Id=r.Id,
                Name = r.Name,
                Street = r.Street,
                City = r.City,
                LaneLength = r.LaneLength,
                ZipCode = r.ZipCode
            }).ToListAsync();
        }

        public async Task<GetSwimmingPoolModel> PostSwimmingPool(PostSwimmingPoolModel model) {
            Guid id = Guid.NewGuid();
            SwimmingPool pool = new SwimmingPool() {
                Id = id,
                City = model.City,
                ZipCode = model.ZipCode,
                LaneLength = model.LaneLength,
                Name = model.Name,
                Street = model.Street,
                Races = new List<Race>(),
                Workouts = new List<Workout>()
            };

            _context.SwimmingPools.Add(pool);
            await _context.SaveChangesAsync();

            return await GetSwimmingPool(id);
        }
    }
}
