using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Results;
using System.Security.Claims;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class ResultsController : ControllerBase {
        private readonly IResultRepository _repo;
        private readonly ClaimsPrincipal _user;

        public ResultsController(IResultRepository repo, IHttpContextAccessor httpContextAccessor) {
            _repo = repo;
            _user = httpContextAccessor.HttpContext.User;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetResultModel>>> GetResult() {
            return await _repo.GetResults();
        }

        [HttpGet("{raceid}/{swimmerid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetResultModel>> GetResult(Guid raceid, Guid swimmerid) {
            if (!_user.IsInRole("Coach") && !_user.IsInRole("Beheerder") && _user.Identity.Name != swimmerid.ToString()) {
                return StatusCode(403);
            }
            GetResultModel result =  await _repo.GetResult(raceid,swimmerid);
            return result==null?new StatusCodeResult(StatusCodes.Status404NotFound):result;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize("Beheerder")]
        public async Task<ActionResult<GetResultModel>> PostResult(PostResultModel result) {
            try {
                var getModel = await _repo.PostResult(result);
                return CreatedAtAction(nameof(PostResult), new { raceid = getModel.RaceId, swimmerid = getModel.SwimmerId }, getModel);
            }
            catch (Exception) {
                return new BadRequestResult();
            }
        }
    }
}
