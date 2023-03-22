using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Swimmers;
using webapi.Entities;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SwimmersController : ControllerBase {
        private readonly ISwimmerRepository _repo;

        public SwimmersController(ISwimmerRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetSwimmerModel>>> GetSwimmer() {
            return await _repo.GetSwimmers();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetSwimmerModel>> GetSwimmer(Guid id) {
            GetSwimmerModel swimmer = await _repo.GetSwimmer(id);
            return swimmer==null? new StatusCodeResult(StatusCodes.Status404NotFound):swimmer;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetSwimmerModel>> PostSwimmer(PostSwimmerModel Swimmer) {
            try {
                var getModel = await _repo.PostSwimmer(Swimmer);
                return CreatedAtAction(nameof(PostSwimmer), new { id = getModel.Id }, getModel);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return new BadRequestResult();
            }
        }
    }
}
