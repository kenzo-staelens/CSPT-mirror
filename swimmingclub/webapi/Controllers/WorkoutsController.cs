using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Workouts;
using System.Security.Claims;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class WorkoutsController : ControllerBase {
        private readonly IWorkoutRepository _repo;
        private readonly ClaimsPrincipal _user;

        public WorkoutsController(IWorkoutRepository repo, IHttpContextAccessor httpContextAccessor) {
            _repo = repo;
            _user = httpContextAccessor.HttpContext.User;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetWorkoutModel>>> GetWorkout() {
            var unfilteredWorkouts = await _repo.GetWorkouts();
            if (_user.IsInRole("Beheerder")) return unfilteredWorkouts;
            else return (from workout in unfilteredWorkouts where workout.CoachId.ToString()==_user.Identity.Name select workout).ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult<GetWorkoutModel>> GetWorkout(Guid id) {
            GetWorkoutModel workout = await _repo.GetWorkout(id);
            if (!_user.IsInRole("Swimmer") && !_user.IsInRole("Beheerder") && _user.Identity.Name != workout.CoachId.ToString()){
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            
            return workout == null?new StatusCodeResult(StatusCodes.Status404NotFound):workout;
        }

        [HttpGet("absences")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize("Beheerder")]
        public async Task<ActionResult<List<GetWorkoutAbsencesModel>>> GetWorkoutAbsences() {
            return await _repo.GetWorkoutAbsences();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize("Beheerder")]
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
