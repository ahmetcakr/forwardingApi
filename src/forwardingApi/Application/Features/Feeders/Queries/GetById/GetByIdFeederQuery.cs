using Application.Features.Feeders.Constants;
using Application.Features.Feeders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Feeders.Constants.FeedersOperationClaims;

namespace Application.Features.Feeders.Queries.GetById;

public class GetByIdFeederQuery : IRequest<GetByIdFeederResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdFeederQueryHandler : IRequestHandler<GetByIdFeederQuery, GetByIdFeederResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFeederRepository _feederRepository;
        private readonly FeederBusinessRules _feederBusinessRules;

        public GetByIdFeederQueryHandler(IMapper mapper, IFeederRepository feederRepository, FeederBusinessRules feederBusinessRules)
        {
            _mapper = mapper;
            _feederRepository = feederRepository;
            _feederBusinessRules = feederBusinessRules;
        }

        public async Task<GetByIdFeederResponse> Handle(GetByIdFeederQuery request, CancellationToken cancellationToken)
        {
            Feeder? feeder = await _feederRepository.GetAsync(predicate: f => f.Id == request.Id, cancellationToken: cancellationToken);
            await _feederBusinessRules.FeederShouldExistWhenSelected(feeder);

            GetByIdFeederResponse response = _mapper.Map<GetByIdFeederResponse>(feeder);
            return response;
        }
    }
}