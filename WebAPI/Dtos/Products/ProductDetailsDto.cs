using WebAPI.Entities.Products;
namespace WebAPI.Dtos.Products;


public record ProductDetailsDto(
    int Id,
    string Ean,
    string Name,
    string Description,
    string Slug,
    int BrandId,
    string Category,
    string SubCategory,
    decimal ListPrice,
    decimal SellingPrice, 
    bool IsInStock,
    List<string> ImageUrls,
    List<Specification>? Specifications);