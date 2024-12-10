using WebAPI.Entities.Products;
namespace WebAPI.Dtos.Products;


public record ProductDetailsDto(
    int Id,
    string Ean,
    string Name,
    string Description,
    string Slug,
    int Brand,
    int CategoryId,
    int SubCategoryId,
    decimal ListPrice,
    decimal SellingPrice, 
    int Stock,
    bool IsInStock,
    string? Specifications,
    List<string> ImageUrls);