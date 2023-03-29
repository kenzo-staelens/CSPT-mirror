using Models.Authenticatie;

namespace webapi.Repositories {
    public interface IPersoonRepository {
        Task<PostAuthenticatieResponseModel> Authenticeer(PostAuthenticatieRequestModel request, string ip);
        Task<PostAuthenticatieResponseModel> VernieuwToken(string token, string ip);
        Task DeactiveerToken(string token, string ip);
    }
}
