using System.Net.Http.Headers;
using TesteTecWF.Services;

namespace TesteTecWF.Handler;

internal class AuthHttpClientHandler : DelegatingHandler
{
    private readonly TokenService _tokenService;

    public AuthHttpClientHandler(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = _tokenService.GetToken();
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
