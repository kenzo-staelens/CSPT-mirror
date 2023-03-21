using Models.Roles;
using System.Diagnostics;
using webapi.Entities;

namespace webapi.Repositories {
    public class RoleRepository : IRoleRepository {

        private SwimmingClubContext _context;
        public RoleRepository(SwimmingClubContext context) {
            _context = context;
        }

        public async Task<GetRoleModel> GetRole(Guid id) {
            return (from r in _context.Roles where r.Id == id select new GetRoleModel() { Description = r.Description }).FirstOrDefault();
            //return role;
        }

        public async Task<List<GetRoleModel>> GetRoles() {
            return (from r in _context.Roles select new GetRoleModel() { Description = r.Description }).ToList();
            //return roles;
        }

        public async Task<GetRoleModel> PostRole(PostRoleModel postRoleModel) {
            GetRoleModel role = new();
            return role;
        }
    }
}
