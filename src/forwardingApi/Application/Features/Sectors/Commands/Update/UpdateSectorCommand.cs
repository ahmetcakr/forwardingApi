using Application.Features.Sectors.Constants;
using Application.Features.Sectors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Sectors.Constants.SectorsOperationClaims;

namespace Application.Features.Sectors.Commands.Update;

public class UpdateSectorCommand : IRequest<UpdatedSectorResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, SectorsOperationClaims.Update };

    public class UpdateSectorCommandHandler : IRequestHandler<UpdateSectorCommand, UpdatedSectorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectorRepository _sectorRepository;
        private readonly SectorBusinessRules _sectorBusinessRules;

        public UpdateSectorCommandHandler(IMapper mapper, ISectorRepository sectorRepository,
                                         SectorBusinessRules sectorBusinessRules)
        {
            _mapper = mapper;
            _sectorRepository = sectorRepository;
            _sectorBusinessRules = sectorBusinessRules;
        }

        public async Task<UpdatedSectorResponse> Handle(UpdateSectorCommand request, CancellationToken cancellationToken)
        {
            Sector? sector = await _sectorRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sectorBusinessRules.SectorShouldExistWhenSelected(sector);
            sector = _mapper.Map(request, sector);

            await _sectorRepository.UpdateAsync(sector!);

            UpdatedSectorResponse response = _mapper.Map<UpdatedSectorResponse>(sector);
            return response;
        }
    }
}