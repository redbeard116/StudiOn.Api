using IdentityService.Models;
using MediatR;
using ResponceModel;

namespace Authentication.Services.Models;

public class RefreshToken : IRequest<ResponseData<AuthResponce>>
{
    public RefreshToken(int userId, string refreshToken)
    {
        UserId = userId;
        Token = refreshToken;
    }

    public int UserId { get; init; }
    public string Token { get; init; }
}
