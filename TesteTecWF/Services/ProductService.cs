using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Services;

internal sealed class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly string baseUrl = "https://localhost:7090/api/product";

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<ResponseProduct>> GetProductsAsync(int pageNumber, int pageSize)
    {
        var response = await _httpClient.GetAsync($"{baseUrl}?pageNumber={pageNumber}&pageSize={pageSize}");

        ResponseProduct responseProduct = await response.Content.ReadFromJsonAsync<ResponseProduct>();
        return new ApiResponse<ResponseProduct>
        {
            Status = response.IsSuccessStatusCode,
            Message = response.ReasonPhrase,
            Data = responseProduct
        };
    }

    public async Task<ApiResponse<Product>> GetProductAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{baseUrl}?productId{id}");
        return new ApiResponse<Product>
        {
            Status = response.IsSuccessStatusCode,
            Message = response.ReasonPhrase,
            Data = await response.Content.ReadFromJsonAsync<Product>()
        };
    }

    public async Task<ApiResponse<Product>> AddProductAsync(Product product)
    {
        var content = CreateContent(product);

        var response = await _httpClient.PostAsync(baseUrl, content);

        if (response.IsSuccessStatusCode)
        {
            return new ApiResponse<Product>
            {
                Status = response.IsSuccessStatusCode,
                Message = response.ReasonPhrase,
                Data = await response.Content.ReadFromJsonAsync<Product>()
            };
        }

        return new ApiResponse<Product>
        {
            Status = response.IsSuccessStatusCode,
            Message = await response.Content.ReadAsStringAsync()
        };
    }

    public async Task<ApiResponse<Product>> UpdateProductAsync(Product product)
    {
        var content = CreateContent(product);

        var response = await _httpClient.PutAsync(baseUrl, content);

        if (response.IsSuccessStatusCode)
        {
            return new ApiResponse<Product>
            {
                Status = response.IsSuccessStatusCode,
                Message = response.ReasonPhrase,
                Data = await response.Content.ReadFromJsonAsync<Product>()
            };
        }

        return new ApiResponse<Product>
        {
            Status = response.IsSuccessStatusCode,
            Message = await response.Content.ReadAsStringAsync()
        };
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{baseUrl}?productId={id}");

        return response.IsSuccessStatusCode;
    }

    private StringContent CreateContent(object obj)
    {
        var json = JsonSerializer.Serialize(obj);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }
}
