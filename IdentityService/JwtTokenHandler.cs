using IdentityService.Models;
using IdentityService.Models.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace IdentityService
{
    public interface IJwtTokenHandler
    {
        AuthResponce GenerateJwtToken(string name, string role, Guid id);
    }

    internal class JwtTokenHandler: IJwtTokenHandler
    {
        #region Fields
        private readonly AuthOptions _authOptions;
        #endregion

        #region Constructor
        public JwtTokenHandler(AuthOptions authOptions)
        {
            _authOptions = authOptions;
        }
        #endregion

        #region IJwtTokenHandler
        public AuthResponce GenerateJwtToken(string name, string role, Guid id)
        {
            var claimIdenity = GetClaimIdentity(id, name, role);
            var accessToken = GetAccessToken(claimIdenity);

            return new AuthResponce
            {
                Id = id,
                UserName = name,
                Token = accessToken,
                RefreshTokenExpiryTime = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(_authOptions.Lifetime)).ToUnixTimeSeconds(),
                RefreshToken = BCrypt.Net.BCrypt.HashPassword(GenerateRefreshToken())
            };
        }
        #endregion

        #region Private methods
        private ClaimsIdentity GetClaimIdentity(Guid userId, string fullName, string role)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, fullName),
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, role);

            return claimsIdentity;
        }

        private string GetAccessToken(ClaimsIdentity claimsIdentity)
        {
            var date = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: _authOptions.Issuer,
                    audience: _authOptions.Audience,
                    notBefore: date,
                    claims: claimsIdentity.Claims,
                    expires: date.Add(TimeSpan.FromMinutes(_authOptions.Lifetime)),
                    signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private string GenerateRefreshToken()
        {
            var random = RandomNumberGenerator.Create();

            var randomBytes = new byte[64];
            random.GetBytes(randomBytes);

            var bytes = Convert.ToBase64String(randomBytes);

            return BCrypt.Net.BCrypt.HashPassword(bytes);
        }
        #endregion
    }
}
