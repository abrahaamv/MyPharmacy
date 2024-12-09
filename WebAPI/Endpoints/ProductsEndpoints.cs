using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dtos.Products;
using WebAPI.Entities.Products;

namespace WebAPI.Endpoints;

public static class ProductsEndpoints
{
    public static RouteGroupBuilder MapProductsEndpoints(this WebApplication app)
    {
        
        var group = app.MapGroup("products");

        //GET /products
        group.MapGet("/", async (ProductsContext dbContext) =>
        {
            var products = await dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .ToListAsync();

            return Results.Ok(products);
        });

        group.MapPost("/", async (CreateProductDto dto, ProductsContext dbContext) =>
        {
            var brand = dbContext.Brands.Find(dto.BrandId);
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
                SubCategoryId = dto.SubCategoryId,
                SubCategory = subCategory,
                Specifications = dto.Specifications,
                ImageUrls = dto.ImageUrls,
                ListPrice = dto.ListPrice,
                SellingPrice = dto.SellingPrice,
                Stock = dto.Stock
            };

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

            return Results.Ok(product);
        });

        return group;
    }
}