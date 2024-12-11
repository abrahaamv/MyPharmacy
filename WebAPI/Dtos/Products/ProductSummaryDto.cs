namespace WebAPI.Dtos.Products;

public record ProductSummaryDto(
    int Id,
    string Ean,
    string Name,
    string Slug,
    string Brand, 
    string Category,
    string? SubCategory,
    decimal ListPrice,
    decimal SellingPrice, 
    bool IsInStock,
    List<string> ImageUrls);