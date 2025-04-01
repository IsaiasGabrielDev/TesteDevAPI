using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Services.AuthenticateService;

public class JwtSecurityKey
{
    public static SymmetricSecurityKey Create(string secret) 
        => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
}
