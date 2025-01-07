using Frontend.Services;



var builder = WebApplication.CreateBuilder(args);

// ✅ Add Required Services
builder.Services.AddServerSideBlazor(); // Enables Blazor Server
builder.Services.AddHttpClient<ProductService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5094/");
}); // Configures HTTP client for ProductService

// ✅ Build Application
var app = builder.Build();

// ✅ Middleware Pipeline Configuration
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ✅ Map Blazor Endpoints
app.MapBlazorHub(); // Enables Blazor SignalR
app.MapFallbackToComponent<Home>("app"); // Fallback to the Home component

app.Run();