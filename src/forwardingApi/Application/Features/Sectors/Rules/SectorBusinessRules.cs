using Application.Features.Sectors.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Sectors.Rules;

public class SectorBusinessRules : BaseBusinessRules
{
    private readonly ISectorRepository _sectorRepository;

    public SectorBusinessRules(ISectorRepository sectorRepository)
    {
        _sectorRepository = sectorRepository;
    }

    public Task SectorShouldExistWhenSelected(Sector? sector)
    {
        if (sector == null)
            throw new BusinessException(SectorsBusinessMessages.SectorNotExists);
        return Task.CompletedTask;
    }

    public async Task SectorIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Sector? sector = await _sectorRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SectorShouldExistWhenSelected(sector);
    }
}