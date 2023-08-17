using Application.Features.Sectors.Constants;
using Application.Features.Sectors.Constants;
using Application.Features.Sectors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Sectors.Constants.SectorsOperationClaims;

namespace Application.Features.Sectors.Commands.Delete;

public class DeleteSectorCommand : IRequest<DeletedSectorResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, SectorsOperationClaims.Delete };

    public class DeleteSectorCommandHandler : IRequestHandler<DeleteSectorCommand, DeletedSectorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectorRepository _sectorRepository;
        private readonly SectorBusinessRules _sectorBusinessRules;

        public DeleteSectorCommandHandler(IMapper mapper, ISectorRepository sectorRepository,
                                         SectorBusinessRules sectorBusinessRules)
        {
            _mapper = mapper;
            _sectorRepository = sectorRepository;
            _sectorBusinessRules = sectorBusinessRules;
        }

        public async Task<DeletedSectorResponse> Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
        {
            Sector? sector = await _sectorRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sectorBusinessRules.SectorShouldExistWhenSelected(sector);

            await _sectorRepository.DeleteAsync(sector!);

            DeletedSectorResponse response = _mapper.Map<DeletedSectorResponse>(sector);
            return response;
        }
    }
}