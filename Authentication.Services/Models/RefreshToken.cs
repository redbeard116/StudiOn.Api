using IdentityService.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using ResponceModel;

namespace Authentication.Services.Models;

public class RefreshToken : IRequest<ResponseData<AuthResponce>>
{
    public RefreshToken(HttpRequest httpRequest, string refreshToken)
    {
        HttpRequest = httpRequest;
        Token = refreshToken;
    }

    public HttpRequest HttpRequest { get; init; }
    public string Token { get; init; }
}
