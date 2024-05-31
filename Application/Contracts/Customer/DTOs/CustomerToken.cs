namespace Application.Contracts.Customer.DTOs;

public class CustomerToken(string accessToken)
{
    public string AccessToken { get; set; } = accessToken;
}