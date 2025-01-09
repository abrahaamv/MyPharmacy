using Frontend.Models;

namespace Frontend.Clients;

public class ProductsClient(HttpClient httpClient)
{
    private readonly List<ProductSummary> products = [];

    public async Task<ProductSummary[]> GetProductsAsync()
        => await httpClient.GetFromJsonAsync<ProductSummary[]>("productos") ?? [];
}