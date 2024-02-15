using System.Data;
using Application.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Services.Implementations;

public class ValidationService(IServiceProvider serviceProvider) : IValidationService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public void EnsureValid<T>(T obj)
    {
        var validator = _serviceProvider.GetService<IValidator<T>>();
        if (validator == null)
        {
            throw new Exception($"Validator for {typeof(T)} not found.");
        }

        var validationResult = validator.Validate(obj);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToDictionary());
        }
    }
}
