using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IdentityService.Models.Settings;

internal class AuthOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public int Lifetime { get; set; }

    public bool ValidateIssuer { get; set; }

    public bool ValidateAudience { get; set; }

    public bool ValidateLifetime { get; set; }

    public bool ValidateIssuerSigningKey { get; set; }

    public TokenValidationParameters GetTokenValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = ValidateIssuer,
            ValidIssuer = Issuer,
            ValidateAudience = ValidateAudience,
            ValidAudience = Audience,
            ValidateLifetime = ValidateLifetime,
            IssuerSigningKey = GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = ValidateIssuerSigningKey,
        };
    }

    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}
