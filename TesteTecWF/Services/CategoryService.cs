using System.Net.Http.Json;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Services;

internal class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7090/api/Category";
    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<IEnumerable<Category>>> GetAllCategoriesAsync()
    {
        var response = await _httpClient.GetAsync(BaseUrl);

        var categories = await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();
        return new ApiResponse<IEnumerable<Category>>
        {
            Status = true,
            Data = categories,
            Message = await response.Content.ReadAsStringAsync()
        };
    }

    public async Task<ApiResponse<Category>> GetCategoryByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}?categoryId={id}");
        if (response.IsSuccessStatusCode)
        {
            var category = await response.Content.ReadFromJsonAsync<Category>();
            return new ApiResponse<Category>
            {
                Status = true,
                Data = category
            };
        }

        return new ApiResponse<Category>
        {
            Status = false,
            Message = await response.Content.ReadAsStringAsync()
        };
    }

    public async Task<ApiResponse<Category>> CreateCategoryAsync(Category category)
    {
        var response = await _httpClient.PostAsJsonAsync(BaseUrl, category);
        if (response.IsSuccessStatusCode)
        {
            var createdCategory = await response.Content.ReadFromJsonAsync<Category>();
            return new ApiResponse<Category>
            {
                Status = true,
                Data = createdCategory
            };
        }
        return new ApiResponse<Category>
        {
            Status = false,
            Message = await response.Content.ReadAsStringAsync()
        };
    }

    public async Task<ApiResponse<Category>> UpdateCategoryAsync(Category category)
    {
        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}", category);
        if (response.IsSuccessStatusCode)
        {
            var updatedCategory = await response.Content.ReadFromJsonAsync<Category>();
            return new ApiResponse<Category>
            {
                Status = true,
                Data = updatedCategory
            };
        }
        return new ApiResponse<Category>
        {
            Status = false,
            Message = await response.Content.ReadAsStringAsync()
        };
    }

    public async Task<ApiResponse<bool>> DeleteCategoryAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return new ApiResponse<bool>
            {
                Status = true,
                Data = true
            };
        }
        return new ApiResponse<bool>
        {
            Status = false,
            Message = await response.Content.ReadAsStringAsync()
        };
    }
}
