using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Authenticatie;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using webapi.Entities;
using webapi.Helper;

namespace webapi.Repositories {
    public class PersoonRepository : IPersoonRepository {
        private readonly SignInManager<Member> _signInManager;
        private readonly UserManager<Member> _userManager;
        private readonly AppSettings _appSettings;

        public PersoonRepository(UserManager<Member> userManager, SignInManager<Member> signInManager, IOptions<AppSettings> appSettings) {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<PostAuthenticatieResponseModel> Authenticeer(PostAuthenticatieRequestModel request, string ip) {
            Member? member = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.Username);
            if(member == null) {
                throw new Exception("User bestaat niet");
            }

            SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(member, request.Password, false);
            if (!signInResult.Succeeded) {
                throw new Exception("ongeldig wachtwoord");
            }

            string JwtToken = await GenereerJwtToken(member);
            RefreshToken refreshToken = GenereerRefreshToken(ip);

            member.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(member);

            return new PostAuthenticatieResponseModel {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Username = member.UserName,
                JwtToken = JwtToken,
                RefreshToken = refreshToken.Token,
                Roles = await _userManager.GetRolesAsync(member)
            };
        }

        public async Task<PostAuthenticatieResponseModel> VernieuwToken(string token, string ip) {
            Member? member = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshTokens.Any(t=>t.Token==token));
            if (member == null) {
                throw new Exception("User bestaat niet");
            }

            RefreshToken refreshToken = member.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive) {
                throw new Exception("ongeldige refresh token");
            }

            RefreshToken newRefreshToken = GenereerRefreshToken(ip);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ip;
            refreshToken.ReplacedByToken = newRefreshToken.Token;

            string jwtToken = await GenereerJwtToken(member);
            member.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(member);

            return new PostAuthenticatieResponseModel {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Username = member.UserName,
                JwtToken = jwtToken,
                RefreshToken = newRefreshToken.Token,
                Roles = await _userManager.GetRolesAsync(member)
            };
        }

        public async Task DeactiveerToken(string token, string ip) {
            Member? member = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshTokens.Any(t => t.Token == token));
            if (member == null) {
                throw new Exception("User bestaat niet");
            }

            RefreshToken refreshToken = member.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive) {
                throw new Exception("ongeldige refresh token");
            }

            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ip;

            await _userManager.UpdateAsync(member);
        }

        public async Task<string> GenereerJwtToken(Member member) {
            var roleNames = await _userManager.GetRolesAsync(member).ConfigureAwait(false);

            List<Claim> claims = new() {
                new Claim(ClaimTypes.Name, member.Id.ToString()),
                new Claim("FirstName", member.FirstName),
                new Claim("LastName", member.LastName),
                new Claim("Username", member.UserName)
            };

            foreach(var rolename in roleNames) {
                claims.Add(new Claim(ClaimTypes.Role, rolename));
            }

            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new() {
                Issuer = "Web API SwimmingClub",
                Subject = new ClaimsIdentity(claims.ToArray()),
                //Expires = DateTime.UtcNow.AddMinutes(5),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public RefreshToken GenereerRefreshToken(string ip) {
            byte[] randombytes = RandomNumberGenerator.GetBytes(64);
            return new RefreshToken {
                Token = Convert.ToBase64String(randombytes),
                //Expires = DateTime.UtcNow.AddMinutes(1440),//24 uur
                Expires = DateTime.UtcNow.AddMinutes(5),
                Created = DateTime.UtcNow,
                CreatedByIp = ip
            };
        }        
    }
}
