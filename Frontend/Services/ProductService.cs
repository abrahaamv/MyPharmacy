namespace Frontend.Services;
using Microsoft.JSInterop;
using Frontend.Models;

public class ProductService
{
    private ProductSummary[]? _products;

    public ProductSummary[]? Products => _products;

    public bool IsLoaded => _products != null;

    public async Task LoadProductsAsync(Func<Task<ProductSummary[]>> fetchProducts)
    {
        if (_products == null)
        {
            _products = await fetchProducts();
        }
    }
}