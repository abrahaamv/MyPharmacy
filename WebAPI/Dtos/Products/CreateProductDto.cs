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
    List<string> ImageUrls,
    List<Specification> Specifications);