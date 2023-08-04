using System.Security.Claims;
using System.Text;
using chores_backend.Utils;
using chores_backend.Data;
using chores_backend.Data.Repositories;
using chores_backend.Models;
using chores_backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ChoresDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

// Authentication and authorization

var issuer = builder.Configuration.GetSection("Jwt").GetSection("Issuer").Value;
var key = builder.Configuration.GetSection("Jwt").GetSection("Key").Value;

//TODO: ValidateAudience error: Bearer error="invalid_token",error_description="The audience 'api' is invalid" set in AuthManager 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidIssuer = issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("master", policy => policy.RequireClaim(ClaimTypes.Role, "master"));
    options.AddPolicy("slave", policy => policy.RequireClaim(ClaimTypes.Role, "slave"));
});

builder.Services.AddIdentityCore<User>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ChoresDbContext>();

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
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
            Enter 'Bearer' [space] and then your token in the text input below.
            Example: 'Bearer 123abcdef",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "0auth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>() 
        }
    });
});

// Cross-origin Resource Sharing

builder.Services.AddCors();

// Automapper

builder.Services.AddAutoMapper(typeof(MapperInitializer));

// DI

builder.Services.AddScoped<ChoresDbDataInitializer>();
builder.Services.AddScoped<IChoresRepository, ChoresRepository>();
builder.Services.AddScoped<IHouseholdsRepository, HouseholdRespository>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

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

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

// Seeding database

using (var scope = app.Services.CreateScope())
{
    var dataInitializer = scope.ServiceProvider.GetRequiredService<ChoresDbDataInitializer>();
    await dataInitializer.SeedDataAsync();
}

app.Run();