using Models.Attendances;
using webapi.Entities;

namespace webapi.Repositories {
    public class AttendanceRepository : IAttendanceRepository {

        private SwimmingClubContext _context;
        public AttendanceRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetAttendanceModel> GetAttendance(Guid id) {
            GetAttendanceModel attendance = new();
            return attendance;
            throw new NotImplementedException();
        }

        public async Task<List<GetAttendanceModel>> GetAttendances() {
            List<GetAttendanceModel> attendance = new();
            return attendance;
            throw new NotImplementedException();
        }

        public async Task<GetAttendanceModel> PostAttendance(PostAttendanceModel postAttendanceModel) {
            GetAttendanceModel attendance = new();
            return attendance;
            throw new NotImplementedException();
        }
    }
}
