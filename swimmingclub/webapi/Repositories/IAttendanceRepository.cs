using Models.Attendances;

namespace webapi.Repositories {
    public interface IAttendanceRepository {
        Task<List<GetAttendanceModel>> GetAttendances();
        Task<GetAttendanceModel> GetAttendance(Guid swimmerid,Guid workoutid);
        Task<GetAttendanceModel> PostAttendance(PostAttendanceModel postAttendanceModel);
    }
}
