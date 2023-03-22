using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Workouts;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase {
        private readonly IWorkoutRepository _repo;

        public WorkoutsController(IWorkoutRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetWorkoutModel>>> GetWorkout() {
            return await _repo.GetWorkouts();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetWorkoutModel>> GetWorkout(Guid id) {
            GetWorkoutModel workout = await _repo.GetWorkout(id);
            return workout == null?new StatusCodeResult(StatusCodes.Status404NotFound):workout;
        }

        [HttpGet("absences")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetWorkoutAbsencesModel>>> GetWorkoutAbsences() {
            return await _repo.GetWorkoutAbsences();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetWorkoutModel>> PostWorkout(PostWorkoutModel workout) {
            try {
                var getModel = await _repo.PostWorkout(workout);
                return CreatedAtAction(nameof(PostWorkout), new { id = getModel.Id }, getModel);
            }
            catch (Exception) {
                return new BadRequestResult();
            }
        }
    }
}
