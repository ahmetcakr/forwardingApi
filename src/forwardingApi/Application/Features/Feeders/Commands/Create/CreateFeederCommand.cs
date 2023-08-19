using Application.Features.Feeders.Constants;
using Application.Features.Feeders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Feeders.Constants.FeedersOperationClaims;

namespace Application.Features.Feeders.Commands.Create;

public class CreateFeederCommand : IRequest<CreatedFeederResponse>, ISecuredRequest, ITransactionalRequest
{
    public string FeederName { get; set; }

    public string[] Roles => new[] { Admin, Write, FeedersOperationClaims.Create };

    public class CreateFeederCommandHandler : IRequestHandler<CreateFeederCommand, CreatedFeederResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFeederRepository _feederRepository;
        private readonly FeederBusinessRules _feederBusinessRules;

        public CreateFeederCommandHandler(IMapper mapper, IFeederRepository feederRepository,
                                         FeederBusinessRules feederBusinessRules)
        {
            _mapper = mapper;
            _feederRepository = feederRepository;
            _feederBusinessRules = feederBusinessRules;
        }

        public async Task<CreatedFeederResponse> Handle(CreateFeederCommand request, CancellationToken cancellationToken)
        {
            Feeder feeder = _mapper.Map<Feeder>(request);

            await _feederRepository.AddAsync(feeder);

            CreatedFeederResponse response = _mapper.Map<CreatedFeederResponse>(feeder);
            return response;
        }
    }
}