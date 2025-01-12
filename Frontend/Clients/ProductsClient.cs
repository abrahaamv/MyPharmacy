using Frontend.Models;

namespace Frontend.Clients;

public class ProductsClient(HttpClient httpClient)
{
    public async Task<ProductSummary[]> GetProductsAsync()
        => await httpClient.GetFromJsonAsync<ProductSummary[]>("productos") ?? [];
    
    public async Task<ProductDetails?> GetProductAsync(string Slug)
    {
        var url = $"productos/{Slug}";
        return await httpClient.GetFromJsonAsync<ProductDetails>(url);
    }

}