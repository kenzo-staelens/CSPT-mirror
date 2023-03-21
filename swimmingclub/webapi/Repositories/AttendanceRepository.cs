using Models.Attendances;
using webapi.Entities;

namespace webapi.Repositories {
    public class AttendanceRepository : IAttendanceRepository {

        private SwimmingClubContext _context;
        public AttendanceRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetAttendanceModel> GetAttendance(Guid swimmerid, Guid workoutid) {
            return (from r in _context.Attendances where r.SwimmerId == swimmerid && r.WorkoutId == workoutid select new GetAttendanceModel() {
                Present = r.Present,
                Remark = r.Remark,
                SwimmerFirstName = r.Swimmer.FirstName,
                SwimmerLastName = r.Swimmer.LastName,
                Schedule = r.Workout.Schedule,
                SwimmingPoolName = r.Workout.SwimmingPool.Name
            }).FirstOrDefault();
        }

        public async Task<List<GetAttendanceModel>> GetAttendances() {
            return (from r in _context.Attendances select new GetAttendanceModel() {
                Present = r.Present,
                Remark = r.Remark,
                SwimmerFirstName = r.Swimmer.FirstName,
                SwimmerLastName = r.Swimmer.LastName,
                Schedule = r.Workout.Schedule,
                SwimmingPoolName = r.Workout.SwimmingPool.Name
            }).ToList();
        }

        public async Task<GetAttendanceModel> PostAttendance(PostAttendanceModel postAttendanceModel) {
            GetAttendanceModel attendance = new();
            return attendance;
        }
    }
}
