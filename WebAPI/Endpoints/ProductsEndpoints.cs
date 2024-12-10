using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dtos.Products;
using WebAPI.Entities.Products;
using WebAPI.Mapping;

namespace WebAPI.Endpoints;

public static class ProductsEndpoints
{
    const string GetProductsEndpointName = "GetProducts";
    public static RouteGroupBuilder MapProductsEndpoints(this WebApplication app)
    {
        
        var group = app.MapGroup("products");
        
//GET /products
        group.MapGet("/", async (ProductsContext dbContext) =>
        {
            var products =  await dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .Select(game => game.ToProductSummaryDto())
                .ToListAsync();

            return Results.Ok(products);
        });
        
//GET /products/{id}        
        group.MapGet("/{id}", async (int id, ProductsContext dbContext) =>
        {
            var product = await dbContext.Products.FindAsync(id);
            
            product!.Brand = await dbContext.Brands.FindAsync(product?.BrandId);
            product!.Category = await dbContext.Categories.FindAsync(product?.CategoryId);
            product!.SubCategory = await dbContext.Subcategories.FindAsync(product?.SubCategoryId);
            
            
            return Results.Ok(product!.ToProductDetailsDto());
        }) .WithName(GetProductsEndpointName);

//POST /products
        group.MapPost("/", async (CreateProductDto dto, ProductsContext dbContext) =>
        {
            var brand = await dbContext.Brands.FindAsync(dto.BrandId);
            var category = await dbContext.Categories.FindAsync(dto.CategoryId);
            var subCategory = await dbContext.Subcategories.FindAsync(dto.SubCategoryId);

            if (brand == null || category == null )
            {
                return Results.BadRequest("Invalid Brand, Category, or SubCategory");
            }

            var product = new Product
            {
                Ean = dto.Ean,
                Name = dto.Name,
                Description = dto.Description,
                Slug = dto.Slug,
                BrandId = dto.BrandId,
                Brand = brand,
                CategoryId = dto.CategoryId,
                Category = category,
                SubCategoryId = 1,
                SubCategory = subCategory,
                Specifications = dto.Specifications,
                ImageUrls = dto.ImageUrls,
                ListPrice = dto.ListPrice,
                SellingPrice = dto.SellingPrice,
                Stock = dto.Stock
            };

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

            return Results.Ok(product.ToProductDetailsDto());
        });

        return group;
    }
}