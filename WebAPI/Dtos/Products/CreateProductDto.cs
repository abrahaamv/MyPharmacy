using WebAPI.Entities.Products;

namespace WebAPI.Dtos.Products;

public record CreateProductDto(
    string Id,
    string Ean,
    string Name,
    string Description,
    string Slug,
    int BrandId,
    int CategoryId,
    int SubCategoryId,
    List<Specification> Specifications,
    List<string> ImageUrls,
    int ListPrice,
    int SellPrice, 
    int Stock);