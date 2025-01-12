using System.Text.Json;
using Frontend.Models;

namespace Frontend.Clients;

public class ProductsClient(HttpClient httpClient)
{
    public async Task<ProductSummary[]> GetProductsAsync()
        => await httpClient.GetFromJsonAsync<ProductSummary[]>("/productos") ?? [];
    
    public async Task<ProductDetails?> GetProductAsync(string slug)
    {
        try
        {
            var url = $"/productos/{slug}";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductDetails>(json);
            }
            else
            {
                Console.WriteLine($"Error fetching product: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching product with slug '{slug}': {ex.Message}");
            return null;
        }
    }


}