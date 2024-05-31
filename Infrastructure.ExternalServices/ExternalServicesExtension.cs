using Application.Repositories;
using Application.Services.Interfaces;
using Infrastructure.ExternalServices.Email;
using Infrastructure.ExternalServices.Email.Contracts;
using Infrastructure.ExternalServices.FileStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.ExternalServices;

public static class ExternalServicesExtension
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services,
        IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddScoped<IFileStorageService, LocalFileStorageService>(provider =>
        {
            var baseDirectory = Path.Combine(environment.ContentRootPath, "wwwroot", "images");
            return new LocalFileStorageService(baseDirectory);
        });
        services.Configure<SmtpClientOptions>(configuration.GetSection("SmtpSettings"));
        services.AddTransient<IEmailService, SmtpEmailService>();

        return services;
    }
}