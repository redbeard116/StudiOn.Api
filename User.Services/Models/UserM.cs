using Newtonsoft.Json;
using TimeServices;

namespace User.Services.Models;

public class UserM
{
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("user_name")]
    public string UserName { get; set; }

    [JsonProperty("login")]
    public string Login { get; set; }

    [JsonProperty("user_type")]
    public UserType UserType { get; set; }

    [JsonProperty("create_date")]
    public long CreateDate => CreateDateInternal.GetUnixTime();

    [JsonIgnore]
    public DateTime CreateDateInternal { get; set; }
}

public class UserType
{
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}