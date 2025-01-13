using System.ComponentModel.DataAnnotations;
using WebAPI.Entities.Products;
namespace WebAPI.Dtos.Products;

public record UpdateProductDto(
    [Required] string Ean,
    [Required] string Name,
    [Required]string Description,
    string Slug,
    [Required] int BrandId,
    int CategoryId,
    int? SubCategoryId,
    [Required] decimal ListPrice,
    [Required] decimal SellingPrice, 
    [Required] int Stock,
    [Required] List<string> ImageUrls,
    List<Specification> Specifications);