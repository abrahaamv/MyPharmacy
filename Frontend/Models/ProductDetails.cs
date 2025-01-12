using System.Text.Json.Serialization;
using WebAPI.Entities.Products;

namespace Frontend.Models;

public class ProductDetails
{
    public int Id { get; set; }

    [JsonPropertyName("ean")]
    public string Ean { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("slug")]
    public string Slug { get; set; } = string.Empty;

    [JsonPropertyName("brandId")]
    public int BrandId { get; set; }

    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }

    [JsonPropertyName("subCategoryId")]
    public int SubCategoryId { get; set; }

    [JsonPropertyName("listPrice")]
    public decimal ListPrice { get; set; }

    [JsonPropertyName("sellingPrice")]
    public decimal SellingPrice { get; set; }

    [JsonPropertyName("isInStock")]
    public bool IsInStock { get; set; }

    [JsonPropertyName("imageUrls")]
    public List<string> ImageUrls { get; set; } = new();

    [JsonPropertyName("specifications")]
    public List<Specification>? Specifications { get; set; }
}