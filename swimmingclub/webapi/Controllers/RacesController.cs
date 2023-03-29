using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Races;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class RacesController : ControllerBase {

        private readonly IRaceRepository _repo;

        public RacesController(IRaceRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetRaceModel>>> GetRace() {
            return await _repo.GetRaces();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult<GetRaceModel>> GetRace(Guid id) {
            GetRaceModel race = await _repo.GetRace(id);
            return race == null ? new StatusCodeResult(StatusCodes.Status404NotFound) : race;
        }

        [HttpGet("results")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize("Beheerder,Coach")]
        public async Task<ActionResult<List<GetRaceResultModel>>> GetRaceResults() {
            return await _repo.GetRaceResults();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize("Beheerder")]
        public async Task<ActionResult<GetRaceModel>> PostRace(PostRaceModel Race) {
            try {
                var getModel = await _repo.PostRace(Race);
                return CreatedAtAction(nameof(PostRace), new { id = getModel.Id }, getModel);
            }
            catch (Exception) {
                return new BadRequestResult();
            }
        }
    }
}
