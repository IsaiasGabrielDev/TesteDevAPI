using System.IdentityModel.Tokens.Jwt;

namespace Core.Services.AuthenticateService.Token;

public class TokenJwt
{
    private JwtSecurityToken token;
    internal TokenJwt(JwtSecurityToken token)
    {
        this.token = token;
    }

    public DateTime ValidTo => token.ValidTo;
    public string vaule => new JwtSecurityTokenHandler().WriteToken(token);
}
