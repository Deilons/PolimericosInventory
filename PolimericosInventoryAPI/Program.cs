using dotenv.net;
using Microsoft.EntityFrameworkCore;
using PolimericosInventoryAPI.Data;
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();
