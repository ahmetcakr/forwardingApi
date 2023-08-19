using Application.Features.Feeders.Constants;
using Application.Features.Feeders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Feeders.Constants.FeedersOperationClaims;

namespace Application.Features.Feeders.Commands.Update;

public class UpdateFeederCommand : IRequest<UpdatedFeederResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string FeederName { get; set; }

    public string[] Roles => new[] { Admin, Write, FeedersOperationClaims.Update };

    public class UpdateFeederCommandHandler : IRequestHandler<UpdateFeederCommand, UpdatedFeederResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFeederRepository _feederRepository;
        private readonly FeederBusinessRules _feederBusinessRules;

        public UpdateFeederCommandHandler(IMapper mapper, IFeederRepository feederRepository,
                                         FeederBusinessRules feederBusinessRules)
        {
            _mapper = mapper;
            _feederRepository = feederRepository;
            _feederBusinessRules = feederBusinessRules;
        }

        public async Task<UpdatedFeederResponse> Handle(UpdateFeederCommand request, CancellationToken cancellationToken)
        {
            Feeder? feeder = await _feederRepository.GetAsync(predicate: f => f.Id == request.Id, cancellationToken: cancellationToken);
            await _feederBusinessRules.FeederShouldExistWhenSelected(feeder);
            feeder = _mapper.Map(request, feeder);

            await _feederRepository.UpdateAsync(feeder!);

            UpdatedFeederResponse response = _mapper.Map<UpdatedFeederResponse>(feeder);
            return response;
        }
    }
}