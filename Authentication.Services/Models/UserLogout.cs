using MediatR;

namespace Authentication.Services.Models;

public class UserLogout:IRequest
{
    public UserLogout(string token)
    {
        Token = token;
    }
    public string Token { get; init; }
}
