using Models.Results;

namespace webapi.Repositories {
    public interface IResultRepository {
        Task<List<GetResultModel>> GetResults();
        Task<GetResultModel> GetResult(Guid raceid, Guid swimmerid);
        Task<GetResultModel> PostResult(PostResultModel postResultModel);
    }
}
