namespace IdentityService.Models.Settings
{
    internal class AppSettings
    {
        public string SecurityKey { get; set; }
        public int TokenValidityMins { get; set; }
        public int KeySize { get; set; }
        public int Iterations { get; set; }
    }
}
