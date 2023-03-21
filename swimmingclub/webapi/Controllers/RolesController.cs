using Microsoft.AspNetCore.Mvc;
using Models.Roles;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase {

        private readonly IRoleRepository _repo;

        public RolesController(IRoleRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetRoleModel>>> GetRole() {
            return await _repo.GetRoles();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetRoleModel>> GetRole(Guid id) {
            GetRoleModel role =  await _repo.GetRole(id);
            return role == null ? new StatusCodeResult(StatusCodes.Status404NotFound) : role;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GetRoleModel> PostRole(PostRoleModel Role) {
            Guid Id = new Guid("12345678-1234-1234-1234-1234567890ab");
            return CreatedAtAction(nameof(PostRole), new { id = Id }, Role);
        }
    }
}
