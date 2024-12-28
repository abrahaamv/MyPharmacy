using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dtos.Products;
using WebAPI.Mapping;

namespace WebAPI.Endpoints;

public static class ProductsEndpoints
{
    const string GetProductsEndpointName = "GetProducts";
    public static RouteGroupBuilder MapProductsEndpoints(this WebApplication app)
    {
        
        var group = app.MapGroup("products")
                        .WithParameterValidation();
        
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
        
//GET /products/{idOrSlug}        
        group.MapGet("/{idOrSlug}", async (string idOrSlug, ProductsContext dbContext) =>
        {
            var product = int.TryParse(idOrSlug, out var id)
                ? await dbContext.Products
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .Include(p => p.SubCategory)
                    .FirstOrDefaultAsync(p => p.Id == id)
                : await dbContext.Products
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .Include(p => p.SubCategory)
                    .FirstOrDefaultAsync(p => p.Slug == idOrSlug);

            if (product is null) return Results.NotFound();
            return Results.Ok(product.ToProductDetailsDto());
        }).WithName("GetProductsEndpointName");


//POST /products
        group.MapPost("/", async (CreateProductDto dto, ProductsContext dbContext) =>
        {
            var product = dto.ToEntity();

            product.Brand = await dbContext.Brands.FindAsync(dto.BrandId);
            product.Category = await dbContext.Categories.FindAsync(dto.CategoryId);
            product.SubCategory = await dbContext.Subcategories.FindAsync(dto.SubCategoryId);
            
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetProductsEndpointName, new {id = product.Id}, product.ToProductSummaryDto());
        });
        
//PUT /products/{id}
    group.MapPut("/{id}", async (int id, UpdateProductDto dto, ProductsContext dbContext) =>
    {
        var product = await dbContext.Products.FindAsync(id);
        
        if (product is null) return Results.NotFound();
        
        dbContext.Entry(product)
                 .CurrentValues
                 .SetValues(dto.ToEntity(id));

        await dbContext.SaveChangesAsync();

        return Results.NoContent();
    });
    
//DELETE /products/{id}
    group.MapDelete("/{id}", async (int id, ProductsContext dbContext) =>
    {
        await dbContext.Products.Where(p => p.Id == id)
                                .ExecuteDeleteAsync();

        return Results.NoContent();
    });
        return group;
    }
}