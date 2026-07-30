using DevPortfolioMVC.Web.Data;
using DevPortfolioMVC.Web.Health;
using DevPortfolioMVC.Web.Models.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if (int.TryParse(
        Environment.GetEnvironmentVariable("PORT"),
        out var platformPort))
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{platformPort}");
}

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Falta la cadena de conexión 'DefaultConnection'. "
        + "En producción configurá la variable "
        + "'ConnectionStrings__DefaultConnection'.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.Configure<PortfolioOptions>(
    builder.Configuration.GetSection(PortfolioOptions.SectionName));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>("database");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapHealthChecks("/health");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

await using (var scope = app.Services.CreateAsyncScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    try
    {
        var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        await DatabaseInitializer.InitializeAsync(context);
    }
    catch (Exception exception)
    {
        logger.LogCritical(
            exception,
            "No fue posible preparar la base de datos.");

        throw;
    }
}

app.Run();
