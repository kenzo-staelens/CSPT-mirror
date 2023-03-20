using Models.SwimmingPools;

namespace webapi.Repositories {
    public interface ISwimmingPoolRepository {
        Task<List<GetSwimmingPoolModel>> GetSwimmingPools();
        Task<GetSwimmingPoolModel> GetSwimmingPool(Guid id);
        Task<GetSwimmingPoolModel> PostSwimmingPool(PostSwimmingPoolModel postSwimmingPoolModel);
    }
}
