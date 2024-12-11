using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync( this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ProductsContext>();
        await dbContext.Database.MigrateAsync();
    }
}
