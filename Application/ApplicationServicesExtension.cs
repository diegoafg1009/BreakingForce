using System.Reflection;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        #region Services

        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFlavorService, FlavorService>();
        services.AddScoped<IObjectiveService, ObjectiveService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ISubcategoryService, SubcategoryService>();

        #endregion

        return services;
    }
}
