using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyPharmacyDatabase");
builder.Services.AddDbContext<ProductsContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MigrateDb();
app.Run();