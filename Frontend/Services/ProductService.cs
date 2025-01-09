using Frontend.Models;
using System.Net.Http.Json;

namespace Frontend.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductSummary>> GetProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("https://intuitive-blessing-production.up.railway.app");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<ProductSummary>>();
            }
            else
            {
                throw new HttpRequestException($"Failed to fetch products. Status code: {response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Error: {ex.Message}");
            return new List<ProductSummary>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
            return new List<ProductSummary>();
        }
    }
}