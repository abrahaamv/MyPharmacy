namespace Frontend.Models;
using System.Text.Json.Serialization;

public class ProductSummary
{
    public int Id { get; set; }

    [JsonPropertyName("ean")]
    public string Ean { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("brand")]
    public string Brand { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("subCategory")]
    public string SubCategory { get; set; }

    [JsonPropertyName("listPrice")]
    public decimal ListPrice { get; set; }

    [JsonPropertyName("sellingPrice")]
    public decimal SellingPrice { get; set; }

    [JsonPropertyName("isInStock")]
    public bool IsInStock { get; set; }

    [JsonPropertyName("imageUrls")]
    public List<string> ImageUrls { get; set; }
}