using Application.Features.Detentions.Constants;
using Application.Features.Detentions.Constants;
using Application.Features.Detentions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Detentions.Constants.DetentionsOperationClaims;

namespace Application.Features.Detentions.Commands.Delete;

public class DeleteDetentionCommand : IRequest<DeletedDetentionResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, DetentionsOperationClaims.Delete };

    public class DeleteDetentionCommandHandler : IRequestHandler<DeleteDetentionCommand, DeletedDetentionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDetentionRepository _detentionRepository;
        private readonly DetentionBusinessRules _detentionBusinessRules;

        public DeleteDetentionCommandHandler(IMapper mapper, IDetentionRepository detentionRepository,
                                         DetentionBusinessRules detentionBusinessRules)
        {
            _mapper = mapper;
            _detentionRepository = detentionRepository;
            _detentionBusinessRules = detentionBusinessRules;
        }

        public async Task<DeletedDetentionResponse> Handle(DeleteDetentionCommand request, CancellationToken cancellationToken)
        {
            Detention? detention = await _detentionRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _detentionBusinessRules.DetentionShouldExistWhenSelected(detention);

            await _detentionRepository.DeleteAsync(detention!);

            DeletedDetentionResponse response = _mapper.Map<DeletedDetentionResponse>(detention);
            return response;
        }
    }
}