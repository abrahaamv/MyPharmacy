namespace WebAPI.Dtos.Products;

public record ProductDto(
    string Id,
    string Ean,
    string Name,
    string Description,
    string Slug,
    int BrandId,
    int CategoryId,
    int SubCategoryId,
    List<SpecificationDto> Specifications,
    List<string> ImageUrls,
    int ListPrice,
    int SellPrice, 
    int Stock);