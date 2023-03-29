using Models.Swimmers;

namespace webapi.Repositories {
    public interface ISwimmerRepository {
        Task<List<GetSwimmerModel>> GetSwimmers();
        Task<GetSwimmerModel> GetSwimmer(Guid id);
        Task<GetSwimmerResultModel> GetSwimmerResult(Guid id);
        Task<GetSwimmerModel> PostSwimmer(PostSwimmerModel postSwimmerModel);
        Task<GetSwimmerModel> PutSwimmer(PutSwimmerModel putSwimmerModel);
    }
}
