using Models.Workouts;
namespace webapi.Repositories {
    public interface IWorkoutRepository {
        Task<List<GetWorkoutModel>> GetWorkouts();
        Task<GetWorkoutModel> GetWorkout(Guid id);
        Task<GetWorkoutModel> PostWorkout(PostWorkoutModel postWorkoutModel);
        Task<List<GetWorkoutAbsencesModel>> GetWorkoutAbsences();
    }
}
