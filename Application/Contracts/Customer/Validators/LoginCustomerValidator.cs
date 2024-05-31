using Application.Contracts.Customer.DTOs;
using FluentValidation;

namespace Application.Contracts.Customer.Validators;

public class LoginCustomerValidator : AbstractValidator<LoginCustomer>
{
    public LoginCustomerValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}