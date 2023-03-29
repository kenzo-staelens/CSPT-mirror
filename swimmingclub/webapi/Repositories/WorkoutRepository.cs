using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Models.Attendances;
using Models.Workouts;
using System.Runtime.CompilerServices;
using webapi.Entities;

namespace webapi.Repositories {
    public class WorkoutRepository : IWorkoutRepository {

        private SwimmingClubContext _context;
        public WorkoutRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetWorkoutModel> GetWorkout(Guid id) {
            return await (from r in _context.Workouts where r.Id == id select new GetWorkoutModel() {
                Id=r.Id,
                CoachId = r.Coach.Id,
                SwimmingPoolName = r.SwimmingPool.Name,
                Schedule = r.Schedule,
                Duration = r.Duration,
                WorkoutType = r.WorkoutType,
                CoachFirstName = r.Coach.FirstName,
                CoachLastName = r.Coach.LastName
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetWorkoutModel>> GetWorkouts() {
            return await (from r in _context.Workouts select new GetWorkoutModel() {
                Id=r.Id,
                CoachId = r.Coach.Id,
                SwimmingPoolName = r.SwimmingPool.Name,
                Schedule = r.Schedule,
                Duration = r.Duration,
                WorkoutType = r.WorkoutType,
                CoachFirstName = r.Coach.FirstName,
                CoachLastName = r.Coach.LastName
            }).ToListAsync();
        }

        public async Task<List<GetWorkoutAbsencesModel>> GetWorkoutAbsences() {
            return await (from r in _context.Workouts where r.Schedule < DateTime.Now
                          && r.Attendances.Where(x => !x.Present).Count() > 0
                          select new GetWorkoutAbsencesModel() {
                              Schedule = r.Schedule,
                              SwimmerNames = (from res in r.Attendances.Where(x=>!x.Present).AsQueryable() select $"{res.Swimmer.FirstName} {res.Swimmer.LastName}").ToList(),
                              
                              CoachFirstName = r.Coach.FirstName,
                              CoachLastName = r.Coach.LastName,
                              
                          }).ToListAsync();
        }

        public async Task<GetWorkoutModel> PostWorkout(PostWorkoutModel postWorkoutModel) {
            Guid id = Guid.NewGuid();
            Workout workout = new Workout() {
                Id = id,
                Duration = postWorkoutModel.Duration,
                Schedule = postWorkoutModel.Schedule,
                WorkoutType = postWorkoutModel.WorkoutType,
                CoachId = postWorkoutModel.CoachId,
                SwimmingPoolId = postWorkoutModel.SwimmingPoolId
            };

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();


            return await GetWorkout(id);
        }
    }
}
