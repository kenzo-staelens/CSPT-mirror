using Models.Swimmers;

namespace webapi.Repositories {
    public interface ISwimmerRepository {
        Task<List<GetSwimmerModel>> GetSwimmers();
        Task<GetSwimmerModel> GetSwimmer(Guid id);
        Task<GetSwimmerModel> PostSwimmer(PostSwimmerModel postSwimmerModel);
    }
}
