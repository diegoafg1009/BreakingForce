using Application.Contracts.Variation.DTOs;
using Application.Exceptions;
using Application.Repositories;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Implementations;

public class VariationService(IUnitOfWork unitOfWork, IMapper mapper) : IVariationService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<GetVariation> GetVariation(Guid id)
    {
        var variation = await _unitOfWork.Variations.GetByIdAsync(id);

        if (variation == null)
        {
            throw new NotFoundException(nameof(ProductVariation), id);
        }
        
        return _mapper.Map<GetVariation>(variation)!;
    }
}