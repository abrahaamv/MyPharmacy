using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyPharmacyDatabase");
builder.Services.AddDbContext<ProductsContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

app.MapProductsEndpoints();
app.MigrateDb();
app.Run();