using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Data.Repositories;
using backend.Services.Interfaces;
using backend.Services.Implementations;
var builder = WebApplication.CreateBuilder(args);

// Logging is configured by default using appsettings.*.json. No extra setup needed here.

// EF Core - SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
  // TODO: confirmar cadena de conexión para Azure SQL en despliegue
  options.UseSqlServer(connectionString);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IIndustryRepository, IndustryRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

// Services
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IIndustryService, IndustryService>();
builder.Services.AddScoped<ILocationService, LocationService>();

// CORS for Blazor WASM frontend
const string CorsPolicyName = "FrontendPolicy";
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
builder.Services.AddCors(options =>
{
  options.AddPolicy(CorsPolicyName, policy =>
  {
    policy.WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();

// Make Program class visible for WebApplicationFactory in tests
public partial class Program { }
