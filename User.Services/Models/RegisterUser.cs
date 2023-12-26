using MediatR;
using Newtonsoft.Json;
using ResponceModel;

namespace User.Services.Models;

public class RegisterUser : IRequest<ResponseData<UserM>>
{
    [JsonProperty("user_name")]
    public string UserName { get; set; }

    [JsonProperty("login")]
    public string Login { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }

    [JsonProperty("user_type_id")]
    public Guid UserTypeId { get; set; }
}