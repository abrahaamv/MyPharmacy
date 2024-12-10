using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dtos.Products;
using WebAPI.Entities.Products;

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
            var products = await dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .ToListAsync();

            return Results.Ok(products);
        });
        
//GET /products/{id}        
        group.MapGet("/{id}", async (int id, ProductsContext dbContext) =>
        {
            var product = await dbContext.Products.FindAsync(id);
            
            var brand = await dbContext.Brands.FindAsync(product?.BrandId);
            var category = await dbContext.Categories.FindAsync(product?.CategoryId);
            var subcategory = await dbContext.Subcategories.FindAsync(product?.SubCategoryId);

            
            var productSummary = new ProductSummaryDto (
                id,
                product!.Ean,
                product.Name,
                product.Slug,
                brand!.Name,
                category!.Name,
                subcategory?.Name,
                product.ListPrice,
                product.SellingPrice,
                product.IsInStock,
                product.ImageUrls?.Take(1).ToList() ?? new List<string>()
            );
            
            return Results.Ok(productSummary);
        }) .WithName(GetProductsEndpointName);

//POST /products
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