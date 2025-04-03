using System.Net.Http.Json;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Services;

internal class ProductHistoryService : IProductHistoryService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7090/api";

    public ProductHistoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<User>> GetUserByEmail(string email)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/Auth");
        if (response.IsSuccessStatusCode)
        {
            var user = await response.Content.ReadFromJsonAsync<User>();
            return new ApiResponse<User>
            {
                Status = true,
                Message = "Success",
                Data = user
            };
        }

        return new ApiResponse<User>
        {
            Status = false,
            Message = await response.Content.ReadAsStringAsync()
        };
    }

    public async Task<ApiResponse<IEnumerable<ProductHistory>>> GetByProductIdAsync(int productId, int userId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/ProductHistory?productId={productId}&userId={userId}");
            if (response.IsSuccessStatusCode)
            {
                var productHistory = await response.Content.ReadFromJsonAsync<IEnumerable<ProductHistory>>();
                return new ApiResponse<IEnumerable<ProductHistory>>
                {
                    Status = true,
                    Message = "Success",
                    Data = productHistory
                };
            }

            return new ApiResponse<IEnumerable<ProductHistory>>
            {
                Status = false,
                Message = await response.Content.ReadAsStringAsync()
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ProductHistory>>
            {
                Status = false,
                Message = ex.Message
            };
        }
    }
}
