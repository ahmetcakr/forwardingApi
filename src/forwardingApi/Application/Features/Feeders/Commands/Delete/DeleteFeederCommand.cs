using Application.Features.Feeders.Constants;
using Application.Features.Feeders.Constants;
using Application.Features.Feeders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Feeders.Constants.FeedersOperationClaims;

namespace Application.Features.Feeders.Commands.Delete;

public class DeleteFeederCommand : IRequest<DeletedFeederResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, FeedersOperationClaims.Delete };

    public class DeleteFeederCommandHandler : IRequestHandler<DeleteFeederCommand, DeletedFeederResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFeederRepository _feederRepository;
        private readonly FeederBusinessRules _feederBusinessRules;

        public DeleteFeederCommandHandler(IMapper mapper, IFeederRepository feederRepository,
                                         FeederBusinessRules feederBusinessRules)
        {
            _mapper = mapper;
            _feederRepository = feederRepository;
            _feederBusinessRules = feederBusinessRules;
        }

        public async Task<DeletedFeederResponse> Handle(DeleteFeederCommand request, CancellationToken cancellationToken)
        {
            Feeder? feeder = await _feederRepository.GetAsync(predicate: f => f.Id == request.Id, cancellationToken: cancellationToken);
            await _feederBusinessRules.FeederShouldExistWhenSelected(feeder);

            await _feederRepository.DeleteAsync(feeder!);

            DeletedFeederResponse response = _mapper.Map<DeletedFeederResponse>(feeder);
            return response;
        }
    }
}