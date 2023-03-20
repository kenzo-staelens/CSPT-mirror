using Models.Attendances;

namespace webapi.Repositories {
    public interface IAttendanceRepository {
        Task<List<GetAttendanceModel>> GetAttendances();
        Task<GetAttendanceModel> GetAttendance(Guid id);
        Task<GetAttendanceModel> PostAttendance(PostAttendanceModel postAttendanceModel);
    }
}
