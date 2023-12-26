using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResponceModel.Extensions;
using User.Services.Models;

namespace User.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
	#region Private methods
	private readonly ILogger<UsersController> _logger;
	private readonly IMediator _mediator;
    #endregion

    #region Constructor
    public UsersController(ILogger<UsersController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    #endregion

    #region Actions
    [HttpPost]
	public async Task<IActionResult> RegisterUser([FromBody]RegisterUser registerUser)
	{
        _logger.LogInformation("POST api/users");
        var result = await _mediator.Send(registerUser);
        return this.Result(result);
	}
	#endregion
}
