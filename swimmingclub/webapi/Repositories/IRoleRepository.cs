using Models.Roles;

namespace webapi.Repositories {
    public interface IRoleRepository {
        Task<List<GetRoleModel>> GetRoles();
        Task<GetRoleModel> GetRole(Guid id);
        Task<GetRoleModel> PostRole(PostRoleModel postRoleModel);
    }
}
