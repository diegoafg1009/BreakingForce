using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Application;
using BreakingForce.API.Endpoints;
using BreakingForce.API.Middlewares;
using Infrastructure.ExternalServices;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Authentication

builder.Services.AddAuthentication()
    .AddJwtBearer("StoreJwtScheme", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:StoreAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:StoreSecretKey"]!))
        };
    })
    .AddJwtBearer("IntranetJwtScheme", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:IntranetAudience"],
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:IntranetSecretKey"]!))
        };
    });

#endregion

#region Authorization

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("StoreScheme", policy =>
    {
        policy.AuthenticationSchemes.Add("StoreJwtScheme");
        policy.RequireAuthenticatedUser();
    })
    .AddPolicy("AdminScheme", policy =>
    {
        policy.AuthenticationSchemes.Add("IntranetJwtScheme");
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Admin");
    });

#endregion

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    // ... Otras configuraciones de Swagger

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // Use "bearer" as the scheme for JWT
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] { } }
    });
});

#endregion

#region ServicesExtension

builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddExternalServices(builder.Configuration, builder.Environment);

#endregion

#region CORS

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()!)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithExposedHeaders("totalRecords", "totalPages");
    });
});

#endregion

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<ApplicationContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception e)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(e, "An error occurred while migrating the database.");
    }
}

app.UseHttpsRedirection();

app.UseAuthentication();
//app.UseAuthorization();

app.UseStaticFiles();

app.UseCors();

var api = app.MapGroup("/v1");
api.MapGroup("/brands").MapBrands();
api.MapGroup("/categories").MapCategories();
api.MapGroup("/customers").MapCustomer();
api.MapGroup("/flavors").MapFlavors();
api.MapGroup("/objectives").MapObjectives();
api.MapGroup("/products").MapProducts();
api.MapGroup("/subcategories").MapSubcategories();
api.MapGroup("/variations").MapVariations();
api.MapGroup("/images").MapImages();

app.Run();