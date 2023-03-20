using Microsoft.Identity.Client;
using Models.Workouts;
using webapi.Entities;

namespace webapi.Repositories {
    public class WorkoutRepository : IWorkoutRepository {

        private SwimmingClubContext _context;
        public WorkoutRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetWorkoutModel> GetWorkout(Guid id) {
            GetWorkoutModel workout = new GetWorkoutModel();
            return workout;
            //throw new NotImplementedException();
        }

        public async Task<List<GetWorkoutModel>> GetWorkouts() {
            List<GetWorkoutModel> workouts = new List<GetWorkoutModel>();
            return workouts;
            throw new NotImplementedException();
        }

        public async Task<GetWorkoutModel> PostWorkout(PostWorkoutModel postWorkoutModel) {
            GetWorkoutModel workout = new GetWorkoutModel();
            return workout;
            throw new NotImplementedException();
        }
    }
}
