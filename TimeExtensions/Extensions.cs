namespace TimeExtensions
{
    public static class Extensions
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long GetUnixTime(this DateTime winTime)
        {
            return new DateTimeOffset(winTime).ToUnixTimeSeconds();
        }
        public static long? GetUnixTime(this DateTime? winTime)
        {
            return winTime.HasValue ? new DateTimeOffset(winTime.Value).ToUnixTimeSeconds() : (long?)null;
        }

        public static DateTime ToLocalTime(this long seconds)
        {
            return UnixEpoch.AddSeconds(seconds).ToLocalTime();
        }
        public static DateTime? ToLocalTime(this long? seconds)
        {
            return seconds?.ToLocalTime();
        }
        public static DateTime ToLocalTimeFromMS(this long milliseconds)
        {
            return UnixEpoch.AddMilliseconds(milliseconds).ToLocalTime();
        }
        public static DateTime? ToLocalTimeFromMS(this long? milliseconds)
        {
            return milliseconds?.ToLocalTimeFromMS();
        }
    }
}
