using Application.Contracts.Variation.DTOs;

namespace Application.Services.Interfaces;

public interface IVariationService
{
    Task<GetVariation> GetVariation(Guid id);
}