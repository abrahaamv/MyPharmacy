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
    List<string> ImageUrls,
    SpecificationDto[] Specifications);