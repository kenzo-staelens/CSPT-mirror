using Microsoft.Identity.Client;
using Models.Attendances;
using Models.Workouts;
using webapi.Entities;

namespace webapi.Repositories {
    public class WorkoutRepository : IWorkoutRepository {

        private SwimmingClubContext _context;
        public WorkoutRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetWorkoutModel> GetWorkout(Guid id) {
            return (from r in _context.Workouts where r.Id == id select new GetWorkoutModel() {
                SwimmingPoolName = r.SwimmingPool.Name,
                Schedule = r.Schedule,
                Duration = r.Duration,
                WorkoutType = r.WorkoutType,
                CoachFirstName = r.Coach.FirstName,
                CoachLastName = r.Coach.LastName
            }).FirstOrDefault();
        }

        public async Task<List<GetWorkoutModel>> GetWorkouts() {
            return (from r in _context.Workouts select new GetWorkoutModel() {
                SwimmingPoolName = r.SwimmingPool.Name,
                Schedule = r.Schedule,
                Duration = r.Duration,
                WorkoutType = r.WorkoutType,
                CoachFirstName = r.Coach.FirstName,
                CoachLastName = r.Coach.LastName
            }).ToList();
        }

        public async Task<List<GetWorkoutAbsencesModel>> GetWorkoutAbsences() {
            return (from r in _context.Workouts where r.Schedule<DateTime.Now
                    select new GetWorkoutAbsencesModel() {
                        SwimmingPoolName = r.SwimmingPool.Name,
                        Schedule = r.Schedule,
                        Duration = r.Duration,
                        WorkoutType = r.WorkoutType,
                        CoachFirstName = r.Coach.FirstName,
                        CoachLastName = r.Coach.LastName,
                        Absences = (from res in _context.Attendances where !r.Attendances.Contains(res) select new GetAttendanceModel() {
                            Present = res.Present,
                            Remark = res.Remark,
                            Schedule = r.Schedule,
                            SwimmerFirstName = res.Swimmer.FirstName,
                            SwimmerLastName = res.Swimmer.LastName,
                            SwimmingPoolName = r.SwimmingPool.Name
                        }).ToList()
                    }).ToList();
        }

        public async Task<GetWorkoutModel> PostWorkout(PostWorkoutModel postWorkoutModel) {
            GetWorkoutModel workout = new GetWorkoutModel();
            return workout;
        }
    }
}
