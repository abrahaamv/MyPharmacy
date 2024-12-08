using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities.Products;
using WebAPI.Dtos.Products;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyPharmacyDatabase");
builder.Services.AddDbContext<ProductsContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

var group = app.MapGroup("products");

//GET /products
group.MapGet("/", (ProductsContext dbContext) =>
{
    var products = dbContext.Products.ToList();
    return Results.Ok(products);
});

//POST /products
group.MapPost("/", (CreateProductDto dto, ProductsContext dbContext) =>
{
    
});

app.MigrateDb();
app.Run();