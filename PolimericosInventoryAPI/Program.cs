using dotenv.net;
using Microsoft.EntityFrameworkCore;
using PolimericosInventoryAPI.Data;
using PolimericosInventoryAPI.Interfaces;
using PolimericosInventoryAPI.Services;

using System;

DotEnv.Load(); // hange this line if you want to load a different .env file

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
var host = Environment.GetEnvironmentVariable("DB_HOST");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password};Ssl Mode=Require;Trust Server Certificate=true;";

// db context 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
// Register services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IInventoryMovementService, InventoryMovementService>();

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

// seeders
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // await DataSeeder.ResetAndSeedAsync(context); // Reset the database and seed it with initial data
    await DataSeeder.SeedAsync(context); // Seed the database with initial data

}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
