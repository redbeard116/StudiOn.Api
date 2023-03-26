namespace IdentityService.Models
{
    public class AuthResponce
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public long RefreshTokenExpiryTime { get; set; }
        public string RefreshToken { get; set; }
    }
}
