using IdentityService.Models;
using MediatR;
using ResponceModel;

namespace Authentication.Services.Models;

public class AuthRequest: IRequest<ResponseData<AuthResponce>>
{
    public string Login { get; set; }
    public string Password { get; set; }
}
