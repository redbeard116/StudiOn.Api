using IdentityService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TimeExtensions;

namespace IdentityService
{
    public interface IJwtTokenHandler
    {
        AuthResponce GenerateJwtToken(string name, string role, int id);
        bool VerifyPassword(string password, string hash, byte[] salt);
    }

    internal class JwtTokenHandler: IJwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "fdkjaldkjfhlaksdfhlaksjfhpruhfmnxvmz";
        private const int JWT_TOKEN_VALIDITY_MINS = 1440;
        private const int keySize = 64;
        private const int iterations = 350000;

        #region IJwtTokenHandler
        public AuthResponce GenerateJwtToken(string name, string role, int id)
        {
            var tokenExpityTime = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, name),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            });

            var signingCreditials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescription = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpityTime,
                SigningCredentials = signingCreditials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescription);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthResponce
            {
                Id = id,
                UserName = name,
                Token = token,
                RefreshTokenExpiryTime = tokenExpityTime.GetUnixTime(),
                RefreshToken = GetRefreshToken(token)
            };
        }

        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password,
                                                          salt,
                                                          iterations,
                                                          HashAlgorithmName.SHA512,
                                                          keySize);

            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        } 
        #endregion

        #region Private methods
        private string GetRefreshToken(string token)
        {
            var salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(token),
                salt,
                iterations,
                HashAlgorithmName.SHA512,
                keySize);
            return Convert.ToHexString(hash);
        }
        #endregion
    }
}
