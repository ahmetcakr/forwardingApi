using Application.Features.Voyages.Constants;
using Application.Features.Voyages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Voyages.Constants.VoyagesOperationClaims;

namespace Application.Features.Voyages.Queries.GetById;

public class GetByIdVoyageQuery : IRequest<GetByIdVoyageResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdVoyageQueryHandler : IRequestHandler<GetByIdVoyageQuery, GetByIdVoyageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVoyageRepository _voyageRepository;
        private readonly VoyageBusinessRules _voyageBusinessRules;

        public GetByIdVoyageQueryHandler(IMapper mapper, IVoyageRepository voyageRepository, VoyageBusinessRules voyageBusinessRules)
        {
            _mapper = mapper;
            _voyageRepository = voyageRepository;
            _voyageBusinessRules = voyageBusinessRules;
        }

        public async Task<GetByIdVoyageResponse> Handle(GetByIdVoyageQuery request, CancellationToken cancellationToken)
        {
            Voyage? voyage = await _voyageRepository.GetAsync(predicate: v => v.Id == request.Id, cancellationToken: cancellationToken);
            await _voyageBusinessRules.VoyageShouldExistWhenSelected(voyage);

            GetByIdVoyageResponse response = _mapper.Map<GetByIdVoyageResponse>(voyage);
            return response;
        }
    }
}