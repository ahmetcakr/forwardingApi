using Application.Features.Sectors.Constants;
using Application.Features.Sectors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Sectors.Constants.SectorsOperationClaims;

namespace Application.Features.Sectors.Queries.GetById;

public class GetByIdSectorQuery : IRequest<GetByIdSectorResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdSectorQueryHandler : IRequestHandler<GetByIdSectorQuery, GetByIdSectorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectorRepository _sectorRepository;
        private readonly SectorBusinessRules _sectorBusinessRules;

        public GetByIdSectorQueryHandler(IMapper mapper, ISectorRepository sectorRepository, SectorBusinessRules sectorBusinessRules)
        {
            _mapper = mapper;
            _sectorRepository = sectorRepository;
            _sectorBusinessRules = sectorBusinessRules;
        }

        public async Task<GetByIdSectorResponse> Handle(GetByIdSectorQuery request, CancellationToken cancellationToken)
        {
            Sector? sector = await _sectorRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sectorBusinessRules.SectorShouldExistWhenSelected(sector);

            GetByIdSectorResponse response = _mapper.Map<GetByIdSectorResponse>(sector);
            return response;
        }
    }
}