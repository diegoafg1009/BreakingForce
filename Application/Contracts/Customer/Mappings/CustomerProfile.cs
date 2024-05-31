using Application.Contracts.Customer.DTOs;
using AutoMapper;

namespace Application.Contracts.Customer.Mappings;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<RegisterCustomer, Domain.Entities.Customer>();
    }
    
}