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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetAttendanceModel>> GetAttendance(Guid id) {
            return await _repo.GetAttendance(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GetAttendanceModel> PostAttendance(PostAttendanceModel attendance) {
            attendance.Id = new Guid("12345678-1234-1234-1234-1234567890ab");
            return CreatedAtAction(nameof(PostAttendance), new { id = attendance.Id }, attendance);
        }
    }
}
