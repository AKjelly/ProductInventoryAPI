using Microsoft.EntityFrameworkCore;
using ProductInventoryAPI.Data;
using ProductInventoryAPI.Repositories;
using ProductInventoryAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// DB Connection
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer("Server=.;Database=ProductInventory;Trusted_Connection=True;TrustServerCertificate=True;"));

//Dependency Injection
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductServices>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
