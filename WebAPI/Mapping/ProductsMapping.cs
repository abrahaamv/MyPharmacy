using System.Linq;
using WebAPI.Dtos.Products;
using WebAPI.Entities.Products;

namespace WebAPI.Mapping;

public static class ProductsMapping
{
        public static ProductSummaryDto ToProductSummaryDto(this Product product)
        {
            return new ProductSummaryDto(
                product.Id,
                product.Ean,
                product.Name,
                product.Slug,
                product.Brand!.Name,
                product.Category!.Name,
                product.SubCategory?.Name,
                product.ListPrice,
                product.SellingPrice,
                product.IsInStock,
                product.ImageUrls?.Take(1).ToList() ?? new List<string>());
        }
        
        public static ProductDetailsDto ToProductDetailsDto(this Product product)
        {
            return new ProductDetailsDto(
                product.Id,
                product.Ean,
                product.Name,
                product.Description,
                product.Slug,
                product.BrandId,
                product.CategoryId,
                product.SubCategoryId,
                product.ListPrice,
                product.SellingPrice,
                product.IsInStock,
                product.ImageUrls,
                product.Specifications);
        }
    

        public static Product ToEntity(this CreateProductDto dto)
        {
            return new Product()
            {
                Ean = dto.Ean,
                Name = dto.Name,
                Description = dto.Description,
                Slug = dto.Slug,
                BrandId = dto.BrandId,
                CategoryId = dto.CategoryId,
                SubCategoryId = 1,
                Specifications = dto.Specifications,
                ImageUrls = dto.ImageUrls,
                ListPrice = dto.ListPrice,
                SellingPrice = dto.SellingPrice,
                Stock = dto.Stock
            };
        }
        public static Product ToEntity(this UpdateProductDto dto, int id)
        {
            return new Product()
            {
                Id = id,
                Ean = dto.Ean,
                Name = dto.Name,
                Description = dto.Description,
                Slug = dto.Slug,
                BrandId = dto.BrandId,
                CategoryId = dto.CategoryId,
                SubCategoryId = dto.SubCategoryId,
                Specifications = dto.Specifications,
                ImageUrls = dto.ImageUrls,
                ListPrice = dto.ListPrice,
                SellingPrice = dto.SellingPrice,
                Stock = dto.Stock
            };
        }
        
}