using TesteTecWF.Models;

namespace TesteTecWF.Interfaces;

public interface IAuthService
{
    Task<ApiResponse<object>> RegisterAsync(Register register);
    Task<ApiResponse<object>> LoginAsync(Login login);
    void LogoutAsync();
}
