using Application.Contracts.Customer.DTOs;
using FluentValidation;

namespace Application.Contracts.Customer.Validators;

public class RegisterCustomerValidator : AbstractValidator<RegisterCustomer>
{
    public RegisterCustomerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithMessage("Surname is required");
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is not valid");
        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone is required");
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters");
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match");
    }
}