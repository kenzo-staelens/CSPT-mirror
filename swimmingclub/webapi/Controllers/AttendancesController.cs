using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Attendances;
using Models.Coaches;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase {
        private readonly IAttendanceRepository _repo;

        public AttendancesController(IAttendanceRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetAttendanceModel>>> GetAttendance() {
            return await _repo.GetAttendances();
        }

        [HttpGet("{swimmerid}/{workoutid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetAttendanceModel>> GetAttendance(Guid swimmerid, Guid workoutid) {
            GetAttendanceModel attendance = await _repo.GetAttendance(swimmerid, workoutid);
            return attendance==null?new StatusCodeResult(StatusCodes.Status404NotFound): attendance;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetAttendanceModel>> PostAttendance(PostAttendanceModel attendance) {
            try {
                var getModel = await _repo.PostAttendance(attendance);
                return CreatedAtAction(nameof(PostAttendance), new { swimmerid = getModel.SwimmerId, workoutid = getModel.WorkoutId }, getModel);
            }
            catch (Exception) {
                return new BadRequestResult();
            }
        }
    }
}
