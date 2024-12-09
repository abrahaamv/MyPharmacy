using WebAPI.Entities.Products;

namespace WebAPI.Dtos.Products;

public record CreateProductDto(
    string Ean,
    string Name,
    string Description,
    string Slug,
    int BrandId,
    int CategoryId,
    int SubCategoryId,
    Specification[] Specifications,
    List<string> ImageUrls,
    int ListPrice,
    int SellingPrice, 
    int Stock);