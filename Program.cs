using System.Security.Claims;
using chores_backend.Configurations;
using chores_backend.Data;
using chores_backend.Data.Repositories;
using chores_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ChoresDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

// Authentication and authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("master", policy => policy.RequireClaim(ClaimTypes.Role, "master"));
    options.AddPolicy("slave", policy => policy.RequireClaim(ClaimTypes.Role, "slave"));
});

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ChoresDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;
    
    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    
    // User settings
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-._@+";
});

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cross-origin Resource Sharing

builder.Services.AddCors();

// Automapper

builder.Services.AddAutoMapper(typeof(MapperInitializer));

// DI

builder.Services.AddScoped<ChoresDbDataInitializer>();
builder.Services.AddScoped<IChoresRepository, ChoresRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Cross-origin Resource Sharing
app.UseCors(
    options => options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// Seeding database

using (var scope = app.Services.CreateScope())
{
    var dataInitializer = scope.ServiceProvider.GetRequiredService<ChoresDbDataInitializer>();
    await dataInitializer.SeedDataAync();
}

app.Run();