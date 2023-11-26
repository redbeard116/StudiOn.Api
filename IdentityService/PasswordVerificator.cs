namespace IdentityService;

public interface IPasswordVerificator
{
    bool Verify(string text, string hash);
}
internal class PasswordVerificator : IPasswordVerificator
{
    #region IPasswordVerificator
    public bool Verify(string text, string hash) => BCrypt.Net.BCrypt.Verify(text, hash);
    #endregion
}
