namespace TesteTecWF.Services;

public sealed class TokenService
{
    private string _token = string.Empty;

    public string GetToken() => _token;

    public void SetToken(string token)
    {
        _token = token;
    }

    public void ClearToken()
    {
        _token = string.Empty;
    }
}
