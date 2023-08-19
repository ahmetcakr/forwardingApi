using Application.Features.Demurrages.Constants;
using Application.Features.Demurrages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Demurrages.Constants.DemurragesOperationClaims;

namespace Application.Features.Demurrages.Queries.GetById;

public class GetByIdDemurrageQuery : IRequest<GetByIdDemurrageResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdDemurrageQueryHandler : IRequestHandler<GetByIdDemurrageQuery, GetByIdDemurrageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDemurrageRepository _demurrageRepository;
        private readonly DemurrageBusinessRules _demurrageBusinessRules;

        public GetByIdDemurrageQueryHandler(IMapper mapper, IDemurrageRepository demurrageRepository, DemurrageBusinessRules demurrageBusinessRules)
        {
            _mapper = mapper;
            _demurrageRepository = demurrageRepository;
            _demurrageBusinessRules = demurrageBusinessRules;
        }

        public async Task<GetByIdDemurrageResponse> Handle(GetByIdDemurrageQuery request, CancellationToken cancellationToken)
        {
            Demurrage? demurrage = await _demurrageRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _demurrageBusinessRules.DemurrageShouldExistWhenSelected(demurrage);

            GetByIdDemurrageResponse response = _mapper.Map<GetByIdDemurrageResponse>(demurrage);
            return response;
        }
    }
}