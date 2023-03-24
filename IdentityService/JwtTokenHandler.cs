using IdentityService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "fdkjaldkjfhlaksdfhlaksjfhpruhfmnxvmz";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccount> _userAccounts;

        public JwtTokenHandler()
        {
            _userAccounts = new List<UserAccount>
            {
                new UserAccount
                {
                    Role = "Admin",
                    Password = "1234",
                    UserName = "test"
                }
            };
        }

        public AuthResponce GenerateJwtToken(AuthRequest authRequest)
        {
            if (string.IsNullOrWhiteSpace(authRequest.UserName) || string.IsNullOrWhiteSpace(authRequest.Password))
            {
                return null;
            }

            var userAccount = _userAccounts.FirstOrDefault(w=> w.UserName == authRequest.UserName && w.Password == authRequest.Password);

            if (userAccount == null)
            {
                return null;
            }

            var tokenExpityTime = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Name, authRequest.UserName),
                new Claim(ClaimTypes.Role, userAccount.Role)
            });

            var signingCreditials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescription = new SecurityTokenDescriptor
            {
                Subject =claimsIdentity,
                Expires = tokenExpityTime,
                SigningCredentials = signingCreditials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescription);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthResponce
            {
                UserName = userAccount.UserName,
                Token = token,
            };
        }
    }
}
