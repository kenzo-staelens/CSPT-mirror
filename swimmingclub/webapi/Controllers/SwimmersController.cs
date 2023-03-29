using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Swimmers;
using System.Net;
using System.Security.Claims;
using webapi.Entities;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class SwimmersController : ControllerBase {
        private readonly ISwimmerRepository _repo;
        private readonly ClaimsPrincipal _user;

        public SwimmersController(ISwimmerRepository repo, IHttpContextAccessor httpContextAccessor) {
            _repo = repo;
            _user = httpContextAccessor.HttpContext.User;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize("Coach,Beheerder")]
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

        [HttpGet("{id}/results")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetSwimmerResultModel>> GetSwimmerResults(Guid id) {
            try {
                if (_user.Identity.Name != id.ToString() && !_user.IsInRole("Beheerder")) {
                    return StatusCode(StatusCodes.Status403Forbidden);
                }

                GetSwimmerResultModel result = await _repo.GetSwimmerResult(id);
                if (result == null) return NotFound();

                return result;
            }
            catch(Exception e) {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize("Beheerder")]
        public async Task<ActionResult<GetSwimmerModel>> PutSwimmer(PutSwimmerModel swimmer) {
            try {
                var getModel = await _repo.PutSwimmer(swimmer);
                return Ok(getModel);
            }
            catch (Exception e) {
                return BadRequest(e);
            }
        }
    }
}
