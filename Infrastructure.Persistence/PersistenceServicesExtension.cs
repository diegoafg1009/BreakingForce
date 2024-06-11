using Application.Repositories;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class PersistenceServicesExtension
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BreakingForceConnection");
        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                mySqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName).EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });

        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
