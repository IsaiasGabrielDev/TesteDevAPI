using System.Text;
using System.Text.Json;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Services;

internal class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly TokenService _tokenService;
    private readonly string baseUrl = "https://localhost:7090/api/auth";

    public AuthService(HttpClient httpClient, TokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
    }

    public async Task<ApiResponse<object>> RegisterAsync(Register register)
    {
        try
        {
            var json = JsonSerializer.Serialize(register);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{baseUrl}/register", content);
            return new ApiResponse<object>
            {
                Status = response.IsSuccessStatusCode,
                Message = response.ReasonPhrase,
                Data = await response.Content.ReadAsStringAsync()
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<object>
            {
                Status = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ApiResponse<object>> LoginAsync(Login login)
    {
        try
        {
            var json = JsonSerializer.Serialize(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{baseUrl}/login", content);
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {

                _tokenService.SetToken(responseString!);
            }

            return new ApiResponse<object>
            {
                Status = response.IsSuccessStatusCode,
                Message = responseString
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<object>
            {
                Status = false,
                Message = ex.Message
            };
        }
    }

    public void LogoutAsync()
    {
        _tokenService.ClearToken();
    }
}