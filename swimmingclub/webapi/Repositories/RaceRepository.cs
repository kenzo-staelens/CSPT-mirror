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
            return (from r in _context.Races where r.Id == id select new GetRaceModel() {
                Schedule = r.Schedule,
                Stroke = r.Stroke,
                AgeCategory = r.AgeCategory,
                Distance = r.Distance,
                Gender = r.Gender
            }).FirstOrDefault();

            
            //return race;
        }

        public async Task<List<GetRaceModel>> GetRaces() {
            return (from r in _context.Races select new GetRaceModel() {
                Schedule = r.Schedule,
                Stroke = r.Stroke,
                AgeCategory = r.AgeCategory,
                Distance = r.Distance,
                Gender = r.Gender
            }).ToList();
            //return races;
        }

        public async Task<List<GetRaceResultModel>> GetRaceResults() {
            return (from r in _context.Races where r.Schedule < DateTime.Now
                    select new GetRaceResultModel() {
                        Schedule = r.Schedule,
                        Stroke = r.Stroke,
                        AgeCategory = r.AgeCategory,
                        Distance = r.Distance,
                        Gender = r.Gender,
                        Results = (from res in _context.Results where r.Results.Contains(res) select
                            new GetResultModel {
                                CurrentPersonalBest = res.CurrentPersonalBest,
                                RaceResult = res.RaceResult,
                                SwimmerFirstName = res.Swimmer.FirstName,
                                SwimmerLastName = res.Swimmer.LastName,
                                Schedule = res.Race.Schedule,
                                SwimmingPoolName = res.Race.SwimmingPool.Name
                            }).ToList()
                    }).ToList();
        }
        public async Task<GetRaceModel> PostRace(PostRaceModel postRaceModel) {
            GetRaceModel race = new();
            return race;
        }
    }
}
