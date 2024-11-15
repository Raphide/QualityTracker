using QualityApi.Data;
using Microsoft.EntityFrameworkCore;
using QualityApi.Cases;
using QualityApi.Product;
using QualityApi.Locations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 4, 2))));

builder.Services.AddScoped<ICaseRepository, CaseRepository>();
builder.Services.AddScoped<CaseService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

var app = builder.Build();

app.MapControllers();
app.Run();