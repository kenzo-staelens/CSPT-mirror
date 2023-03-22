using Microsoft.EntityFrameworkCore;
using Models.Attendances;
using webapi.Entities;

namespace webapi.Repositories {
    public class AttendanceRepository : IAttendanceRepository {

        private SwimmingClubContext _context;
        public AttendanceRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetAttendanceModel> GetAttendance(Guid swimmerid, Guid workoutid) {
            return await (from r in _context.Attendances where r.SwimmerId == swimmerid && r.WorkoutId == workoutid select new GetAttendanceModel() {
                SwimmerId = r.SwimmerId,
                WorkoutId = r.WorkoutId,
                Present = r.Present,
                Remark = r.Remark,
                SwimmerFirstName = r.Swimmer.FirstName,
                SwimmerLastName = r.Swimmer.LastName,
                Schedule = r.Workout.Schedule,
                SwimmingPoolName = r.Workout.SwimmingPool.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetAttendanceModel>> GetAttendances() {
            return await (from r in _context.Attendances select new GetAttendanceModel() {
                SwimmerId = r.SwimmerId,
                WorkoutId = r.WorkoutId,
                Present = r.Present,
                Remark = r.Remark,
                SwimmerFirstName = r.Swimmer.FirstName,
                SwimmerLastName = r.Swimmer.LastName,
                Schedule = r.Workout.Schedule,
                SwimmingPoolName = r.Workout.SwimmingPool.Name
            }).ToListAsync();
        }

        public async Task<GetAttendanceModel> PostAttendance(PostAttendanceModel postAttendanceModel) {
            Attendance attendance = new Attendance() {
                WorkoutId = postAttendanceModel.WorkoutId,
                SwimmerId = postAttendanceModel.SwimmerId,
                Remark = postAttendanceModel.Remark,
                Present = postAttendanceModel.Present
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return await GetAttendance(postAttendanceModel.SwimmerId, postAttendanceModel.WorkoutId);
        }
    }
}
