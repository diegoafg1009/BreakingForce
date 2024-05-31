using Application.Contracts.Customer.DTOs;
using Application.Contracts.RegisterConfirmation.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BreakingForce.API.Endpoints;

public static class CustomerEndpoint
{
    public static RouteGroupBuilder MapCustomer(this RouteGroupBuilder group)
    {
        group.MapPost("/login", Login);
        group.MapPost("/register", Register);
        group.MapPost("/confirm-register", RegisterConfirmation);
        return group;
    }

    private static async Task<Ok<CustomerToken>> Login([FromServices] ICustomerService customerService,
        [FromBody] LoginCustomer model)
    {
        var token = await customerService.Login(model);
        return TypedResults.Ok(token);
    }

    private static async Task<Ok<string>> Register([FromServices] ICustomerService customerService,
        [FromBody] RegisterCustomer model)
    {
        await customerService.Register(model);
        return TypedResults.Ok("Customer registered successfully");
    }

    private static async Task<Ok<CustomerToken>> RegisterConfirmation([FromServices] ICustomerService customerService,
        [FromBody] RegisterConfirmationRequest model)
    {
        var customerToken = await customerService.RegisterConfirmation(model);
        return TypedResults.Ok(customerToken);
    }
}