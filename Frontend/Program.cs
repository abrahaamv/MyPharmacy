using Frontend.Clients;
using Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var myPharmacyApiUrl = builder.Configuration["MyPharmacyApiUrl"] // ??
                  //     throw new Exception("MyPharmacyApiUrl is not set")
                  ;

builder.Services.AddHttpClient<ProductsClient>(client =>
{
    client.BaseAddress = new Uri(myPharmacyApiUrl ?? throw new InvalidOperationException());
}).ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>();

app.Run();
