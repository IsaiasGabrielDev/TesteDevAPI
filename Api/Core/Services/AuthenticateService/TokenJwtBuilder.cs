﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Services.AuthenticateService;

public class TokenJwtBuilder
{
    private SecurityKey? securityKey = null;
    private string subject = string.Empty;
    private string issuer = string.Empty;
    private string audience = string.Empty;
    private string email = string.Empty;
    private Dictionary<string, string> claims = new();
    private int expiryMinutes = 60;

    public TokenJwtBuilder AddSecurityKey(SecurityKey? securityKey)
    {
        this.securityKey = securityKey;
        return this;
    }

    public TokenJwtBuilder AddSubject(string subject)
    {
        this.subject = subject; return this;
    }

    public TokenJwtBuilder AddIssuer(string issuer)
    {
        this.issuer = issuer;
        return this;
    }

    public TokenJwtBuilder AddAudience(string audience)
    {
        this.audience = audience;
        return this;
    }

    public TokenJwtBuilder AddEmail(string email)
    {
        this.email = email;
        return this;
    }

    public TokenJwtBuilder AddClaims(string type, string value)
    {
        this.claims.Add(type, value);
        return this;
    }

    public TokenJwtBuilder AddClaims(Dictionary<string, string> claims)
    {
        this.claims.Union(claims);
        return this;
    }

    public TokenJwtBuilder AddExpiry(int expiryMinutes)
    {
        this.expiryMinutes = expiryMinutes;
        return this;
    }

    private void EnsureArguments()
    {
        if (this.securityKey is null)
            throw new ArgumentNullException(nameof(this.securityKey));
        if (string.IsNullOrEmpty(subject))
            throw new ArgumentNullException(nameof(this.subject));
        if (string.IsNullOrEmpty(this.issuer))
            throw new ArgumentNullException(nameof(this.issuer));
        if (string.IsNullOrEmpty(this.audience))
            throw new ArgumentNullException(nameof(this.audience));
    }

    public TokenJwt Builder()
    {
        EnsureArguments();

        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, this.audience),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Email, this.email)
        };

        claims.AddRange(this.claims.Select(item => new Claim(item.Key, item.Value)));

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: new SigningCredentials(this.securityKey, SecurityAlgorithms.HmacSha256));

        return new TokenJwt(token);
    }
}
