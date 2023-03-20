using Models.Coaches;

namespace webapi.Repositories {
    public interface ICoachRepository {
        Task<List<GetCoachModel>> GetCoaches();
        Task<GetCoachModel> GetCoach(Guid id);
        Task<GetCoachModel> PostCoach(PostCoachModel postCoachModel);
    }
}
