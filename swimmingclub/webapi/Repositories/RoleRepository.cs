using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Roles;
using System.Diagnostics;
using webapi.Entities;

namespace webapi.Repositories {
    public class RoleRepository : IRoleRepository {

        private SwimmingClubContext _context;
        private RoleManager<Role> _roleManager;
        public RoleRepository(SwimmingClubContext context, RoleManager<Role> roleManager) {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<GetRoleModel> GetRole(Guid id) {
            return await (from r in _context.Roles where r.Id == id select new GetRoleModel() {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetRoleModel>> GetRoles() {
            return await (from r in _context.Roles select new GetRoleModel() {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToListAsync();
        }

        public async Task<GetRoleModel> PostRole(PostRoleModel postRoleModel) {
            Guid id = Guid.NewGuid();
            Role role = new Role() {
                Id = id,
                Description = postRoleModel.Description,
                Name = postRoleModel.Name
            };

            IdentityResult result = await _roleManager.CreateAsync(role);
            return await GetRole(id);
        }
    }
}
