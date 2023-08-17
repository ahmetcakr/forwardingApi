using Application.Features.Sectors.Constants;
using Application.Features.Sectors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Sectors.Constants.SectorsOperationClaims;

namespace Application.Features.Sectors.Commands.Create;

public class CreateSectorCommand : IRequest<CreatedSectorResponse>, ISecuredRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, SectorsOperationClaims.Create };

    public class CreateSectorCommandHandler : IRequestHandler<CreateSectorCommand, CreatedSectorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectorRepository _sectorRepository;
        private readonly SectorBusinessRules _sectorBusinessRules;

        public CreateSectorCommandHandler(IMapper mapper, ISectorRepository sectorRepository,
                                         SectorBusinessRules sectorBusinessRules)
        {
            _mapper = mapper;
            _sectorRepository = sectorRepository;
            _sectorBusinessRules = sectorBusinessRules;
        }

        public async Task<CreatedSectorResponse> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
        {
            Sector sector = _mapper.Map<Sector>(request);

            await _sectorRepository.AddAsync(sector);

            CreatedSectorResponse response = _mapper.Map<CreatedSectorResponse>(sector);
            return response;
        }
    }
}