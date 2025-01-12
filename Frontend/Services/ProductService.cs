using Frontend.Models;
using Frontend.Clients;
namespace Frontend.Services;


public class ProductService
{
    private ProductSummary[]? _products;

    public ProductSummary[]? Products => _products;

    public bool IsLoaded => _products != null;

    private readonly ProductsClient _productsClient;

    public ProductService(ProductsClient productsClient)
    {
        _productsClient = productsClient;
    }

    // Load all products (optional, depending on your use case)
    public async Task LoadProductsAsync(Func<Task<ProductSummary[]>> productsAsync)
    {
        if (_products == null)
        {
            _products = await _productsClient.GetProductsAsync();
        }
    }

    // Fetch a specific product by slug
    public async Task<ProductDetails?> GetProductBySlugAsync(string slug)
    {
        return await _productsClient.GetProductAsync(slug);
    }
}