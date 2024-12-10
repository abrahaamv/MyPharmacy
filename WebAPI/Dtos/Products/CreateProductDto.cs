using WebAPI.Entities.Products;

namespace WebAPI.Dtos.Products;

public record CreateProductDto(
    string Ean,
    string Name,
    string Description,
    string Slug,
    int BrandId,
    int CategoryId,
    int? SubCategoryId,
    decimal ListPrice,
    decimal SellingPrice, 
    int Stock,
    string Specifications,
    List<string> ImageUrls);