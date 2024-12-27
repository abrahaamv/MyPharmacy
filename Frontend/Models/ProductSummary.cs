namespace Frontend.Models;

public class Product
{
    public int Id { get; set; }
    public required string Ean { get; set; }
    public required string Name { get; set; }
    public required string Slug { get; set; }
    public  required string Brand { get; set; }
    public required string Category { get; set; }
    public string? SubCategory { get; set; }
    public decimal ListPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public bool IsInStock { get; set; }
    public required List<string> ImageUrls { get; set; }
}

