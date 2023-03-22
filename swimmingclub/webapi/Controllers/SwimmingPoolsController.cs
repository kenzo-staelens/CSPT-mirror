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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetSwimmingPoolModel>> GetSwimmingPool(Guid id) {
            GetSwimmingPoolModel swimmingpool =  await _repo.GetSwimmingPool(id);
            return swimmingpool==null? new StatusCodeResult(StatusCodes.Status404NotFound):swimmingpool;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetSwimmingPoolModel>> PostSwimmingPool(PostSwimmingPoolModel swimmingPool) {
            try {
                var getModel = await _repo.PostSwimmingPool(swimmingPool);
                return CreatedAtAction(nameof(PostSwimmingPool), new { id = getModel.Id }, getModel);
            }catch(Exception) {
                return new BadRequestResult();
            }
        }
    }
}
