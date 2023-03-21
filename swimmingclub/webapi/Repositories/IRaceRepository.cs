using Models.Races;

namespace webapi.Repositories {
    public interface IRaceRepository {
        Task<List<GetRaceModel>> GetRaces();
        Task<GetRaceModel> GetRace(Guid id);
        Task<List<GetRaceResultModel>> GetRaceResults();
        Task<GetRaceModel> PostRace(PostRaceModel postRaceModel);
    }
}
