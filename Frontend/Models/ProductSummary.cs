namespace Frontend.Models;
using System.Text.Json.Serialization;

public class ProductSummary
{
    public int Id { get; set; }

    [JsonPropertyName("ean")]
    public  required string Ean { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("slug")]
    public required string Slug { get; set; }

    [JsonPropertyName("brand")]
    public required string Brand { get; set; }

    [JsonPropertyName("category")]
    public required  string Category { get; set; }

    [JsonPropertyName("subCategory")]
    public string? SubCategory { get; set; }

    [JsonPropertyName("listPrice")]
    public decimal ListPrice { get; set; }

    [JsonPropertyName("sellingPrice")]
    public decimal SellingPrice { get; set; }

    [JsonPropertyName("isInStock")]
    public bool IsInStock { get; set; }

    [JsonPropertyName("imageUrls")]
    public required List<string> ImageUrls { get; set; }
}