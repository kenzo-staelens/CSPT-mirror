using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Authenticatie;
using Models.Swimmers;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class GebruikersController : ControllerBase {

        private readonly IPersoonRepository _repo;

        public GebruikersController(IPersoonRepository repo) {
            _repo = repo;
        }

        [HttpPost("authenticeer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [AllowAnonymous]
        public async Task<ActionResult<PostAuthenticatieResponseModel>> Authenticeer(PostAuthenticatieRequestModel request) {
            try {
                PostAuthenticatieResponseModel response = await _repo.Authenticeer(request, IpAddress());
                SetTokenCookie(response.RefreshToken);
                return response;
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("vernieuw-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [AllowAnonymous]
        public async Task<ActionResult<PostAuthenticatieResponseModel>> Vernieuwtoken() {
            try {
                string refreshToken = Request.Cookies["webapi.RefreshToken"];

                PostAuthenticatieResponseModel response = await _repo.VernieuwToken(refreshToken, IpAddress());
                SetTokenCookie(response.RefreshToken);
                return response;
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("deactiveer-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [AllowAnonymous]
        //[Authorize(Roles = "Beheerder")]
        public async Task<ActionResult<PostAuthenticatieResponseModel>> DeactiveerToken(PostAuthenticatieDeactivateRequestModel request) {
            try {
                string token = request.Token ?? Request.Cookies["webapi.RefreshToken"];

                if (string.IsNullOrEmpty(token)) {
                    throw new Exception("token is required");
                }

                await _repo.DeactiveerToken(token, IpAddress());
                return Ok();
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        private void SetTokenCookie(string token) {
            CookieOptions options = new() {
                HttpOnly = true,
                //Expires = DateTime.UtcNow.AddMinutes(1440),//24 uur
                Expires = DateTime.UtcNow.AddMinutes(5),
                IsEssential = true
            };

            Response.Cookies.Append("webapi.RefreshToken", token, options);
        }

        private string IpAddress() {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) {
                return Request.Headers["X-Forwarded-For"];
            }
            else {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }
    }
}
