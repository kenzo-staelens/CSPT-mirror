using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.SwimmingPools;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SwimmingPoolsController : ControllerBase {
        private readonly ISwimmingPoolRepository _repo;

        public SwimmingPoolsController(ISwimmingPoolRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetSwimmingPoolModel>>> GetSwimmingPool() {
            return await _repo.GetSwimmingPools();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetSwimmingPoolModel>> GetSwimmingPool(Guid id) {
            return await _repo.GetSwimmingPool(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GetSwimmingPoolModel> PostSwimmingPool(PostSwimmingPoolModel SwimmingPool) {
            SwimmingPool.Id = new Guid("12345678-1234-1234-1234-1234567890ab");
            return CreatedAtAction(nameof(PostSwimmingPool), new { id = SwimmingPool.Id }, SwimmingPool);
        }
    }
}
