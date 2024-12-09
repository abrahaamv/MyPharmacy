namespace WebAPI.Dtos.Products;

public record ProductDto(
    int Id,
    string Ean,
    string Name,
    string Description,
    string Slug,
    int BrandId,
    int CategoryId,
    int SubCategoryId,
    SpecificationDto[] Specifications,
    List<string> ImageUrls,
    int ListPrice,
    int SellingPrice, 
    int Stock);