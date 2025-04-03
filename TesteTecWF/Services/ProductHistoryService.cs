using System.Net.Http.Json;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Services;

internal class ProductHistoryService : IProductHistoryService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7090/api/ProductHistory";

    public ProductHistoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<IEnumerable<ProductHistory>>> GetByProductIdAsync(int productId, int userId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}?productId={productId}&userId={userId}");
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
