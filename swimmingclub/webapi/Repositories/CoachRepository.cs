using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Coaches;
using Models.Swimmers;
using webapi.Entities;

namespace webapi.Repositories {
    public class CoachRepository : ICoachRepository {

        private readonly SwimmingClubContext _context;
        private readonly UserManager<Member> _userManager;
        public CoachRepository(SwimmingClubContext context, UserManager<Member> userManager) {
            _context = context;
            _userManager = userManager;
        }

        public async Task<GetCoachModel> GetCoach(Guid id) {
            return await (from r in _context.Coaches
                          where r.Id == id
                          select new GetCoachModel() {
                              Id = r.Id,
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              DateOfBirth = r.DateOfBirth,
                              Level = r.Level,
                              Gender = r.Gender,
                              Username = r.UserName,
                              Email = r.Email
                          }).FirstOrDefaultAsync();

        }

        public async Task<List<GetCoachModel>> GetCoaches() {
            return await (from r in _context.Coaches
                          select new GetCoachModel() {
                              Id = r.Id,
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              DateOfBirth = r.DateOfBirth,
                              Level = r.Level,
                              Gender = r.Gender,
                              Username = r.UserName,
                              Email = r.Email
                          }).ToListAsync();
        }

        public async Task<GetCoachModel> PostCoach(PostCoachModel postCoachModel) {
            Guid id = Guid.NewGuid();
            Coach coach = new Coach {
                Id = id,
                DateOfBirth = postCoachModel.DateOfBirth,
                FirstName = postCoachModel.FirstName,
                LastName = postCoachModel.LastName,
                Gender = postCoachModel.Gender,
                Level = postCoachModel.Level,
                UserName = postCoachModel.Username,
                Email = postCoachModel.Email
                //UserName = $"{postCoachModel.FirstName} {postCoachModel.LastName}"
            };
            IdentityResult result = await _userManager.CreateAsync(coach, postCoachModel.Password);
            return await GetCoach(id);
        }

        public async Task<GetCoachModel> PutCoach(PutCoachModel putCoachModel) {
            var coach = await (from r in _context.Coaches where r.Id == putCoachModel.Id select r).FirstOrDefaultAsync();
            if (coach != null) {
                await _userManager.AddToRolesAsync(coach, putCoachModel.RoleNames);
            }
            return await GetCoach(putCoachModel.Id);
        }
    }
}
