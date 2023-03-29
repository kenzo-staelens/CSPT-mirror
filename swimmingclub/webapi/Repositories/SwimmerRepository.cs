using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Coaches;
using Models.Results;
using Models.Swimmers;
using webapi.Entities;

namespace webapi.Repositories {
    public class SwimmerRepository : ISwimmerRepository {

        private SwimmingClubContext _context;
        private UserManager<Member> _userManager;

        public SwimmerRepository(SwimmingClubContext context, UserManager<Member> userManager) {
            _context = context;
            _userManager = userManager;

        }
        public async Task<GetSwimmerModel> GetSwimmer(Guid id) {
            return await (from r in _context.Swimmers
                          where r.Id == id
                          select new GetSwimmerModel() {
                              Id = r.Id,
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              DateOfBirth = r.DateOfBirth,
                              Gender = r.Gender,
                              FinalPoints = r.FinalPoints,
                              Username = r.UserName,
                              Email = r.Email
                          })
            .FirstOrDefaultAsync();
        }

        public async Task<GetSwimmerResultModel?> GetSwimmerResult(Guid id) {
            return await (from r in _context.Swimmers
                          where r.Id == id
                          select new GetSwimmerResultModel() {
                              Id = r.Id,
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              DateOfBirth = r.DateOfBirth,
                              Gender = r.Gender,
                              FinalPoints = r.FinalPoints,
                              Username = r.UserName,
                              Email = r.Email,
                              RaceResults = (from res in _context.Results where res.SwimmerId == id select new GetResultModel() {
                                  RaceId = res.RaceId,
                                  SwimmerId = res.SwimmerId,
                                  CurrentPersonalBest = res.CurrentPersonalBest,
                                  RaceResult = res.RaceResult,
                                  SwimmerFirstName = res.Swimmer.FirstName,
                                  SwimmerLastName = res.Swimmer.LastName,
                                  Schedule = res.Race.Schedule,
                                  SwimmingPoolName = res.Race.SwimmingPool.Name
                              }).ToList()
                          }).FirstOrDefaultAsync();
        }

        public async Task<List<GetSwimmerModel>> GetSwimmers() {
            return await (from r in _context.Swimmers
                          select new GetSwimmerModel() {
                              Id = r.Id,
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              DateOfBirth = r.DateOfBirth,
                              Gender = r.Gender,
                              FinalPoints = r.FinalPoints,
                              Username = r.UserName,
                              Email = r.Email
                          }).ToListAsync();
        }

        public async Task<GetSwimmerModel> PostSwimmer(PostSwimmerModel postSwimmerModel) {
            Guid id = Guid.NewGuid();
            Swimmer swimmer = new Swimmer() {
                Id = id,
                DateOfBirth = postSwimmerModel.DateOfBirth,
                FirstName = postSwimmerModel.FirstName,
                LastName = postSwimmerModel.LastName,
                Gender = postSwimmerModel.Gender,
                FinalPoints = postSwimmerModel.FinalPoints,
                UserName = postSwimmerModel.Username,
                Email = postSwimmerModel.Email
                //UserName = $"{postSwimmerModel.FirstName} {postSwimmerModel.LastName}"
            };
            IdentityResult result = await _userManager.CreateAsync(swimmer, postSwimmerModel.Password);

            return await GetSwimmer(id);
        }

        public async Task<GetSwimmerModel> PutSwimmer(PutSwimmerModel putSwimmerModel) {
            var swimmer = await (from r in _context.Swimmers where r.Id == putSwimmerModel.Id select r).FirstOrDefaultAsync();
            if (swimmer != null) {
                await _userManager.AddToRolesAsync(swimmer, putSwimmerModel.RoleNames);
            }
            return await GetSwimmer(putSwimmerModel.Id);
        }
    }
}
