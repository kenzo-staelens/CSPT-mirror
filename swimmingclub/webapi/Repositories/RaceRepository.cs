using Microsoft.EntityFrameworkCore;
using Models.Races;
using Models.Results;
using System.Diagnostics;
using webapi.Entities;

namespace webapi.Repositories {
    public class RaceRepository : IRaceRepository {

        private SwimmingClubContext _context;
        public RaceRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetRaceModel> GetRace(Guid id) {
            return await (from r in _context.Races where r.Id == id select new GetRaceModel() {
                Id = r.Id,
                Schedule = r.Schedule,
                Stroke = r.Stroke,
                AgeCategory = r.AgeCategory,
                Distance = r.Distance,
                Gender = r.Gender,
                SwimmingPoolName = r.SwimmingPool.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetRaceModel>> GetRaces() {
            return await(from r in _context.Races select new GetRaceModel() {
                Id = r.Id,
                Schedule = r.Schedule,
                Stroke = r.Stroke,
                AgeCategory = r.AgeCategory,
                Distance = r.Distance,
                Gender = r.Gender,
                SwimmingPoolName = r.SwimmingPool.Name
            }).ToListAsync();
        }

        public async Task<List<GetRaceResultModel>> GetRaceResults() {
            return await (from r in _context.Races where r.Schedule < DateTime.Now
                    select new GetRaceResultModel() {
                        SwimmingPoolName = r.SwimmingPool.Name,
                        Results = (from res in _context.Results where r.Results.Contains(res) select
                            new RaceResultSubModel {
                                RaceResult = res.RaceResult,
                                SwimmerName = $"{res.Swimmer.FirstName} {res.Swimmer.LastName}",
                            }).ToList()
                    }).ToListAsync();
        }
        public async Task<GetRaceModel> PostRace(PostRaceModel postRaceModel) {
            Guid id = Guid.NewGuid();
            Race race = new Race() {
                Id = id,
                AgeCategory = postRaceModel.AgeCategory,
                Distance = postRaceModel.Distance,
                Gender = postRaceModel.Gender,
                Schedule = postRaceModel.Schedule,
                Stroke = postRaceModel.Stroke,
                SwimmingPoolId = postRaceModel.SwimmingPoolId
            };
            _context.Races.Add(race);
            await _context.SaveChangesAsync();

            return await GetRace(id);
        }
    }
}
