using Application.Features.Detentions.Constants;
using Application.Features.Detentions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Detentions.Constants.DetentionsOperationClaims;

namespace Application.Features.Detentions.Commands.Update;

public class UpdateDetentionCommand : IRequest<UpdatedDetentionResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }

    public string[] Roles => new[] { Admin, Write, DetentionsOperationClaims.Update };

    public class UpdateDetentionCommandHandler : IRequestHandler<UpdateDetentionCommand, UpdatedDetentionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDetentionRepository _detentionRepository;
        private readonly DetentionBusinessRules _detentionBusinessRules;

        public UpdateDetentionCommandHandler(IMapper mapper, IDetentionRepository detentionRepository,
                                         DetentionBusinessRules detentionBusinessRules)
        {
            _mapper = mapper;
            _detentionRepository = detentionRepository;
            _detentionBusinessRules = detentionBusinessRules;
        }

        public async Task<UpdatedDetentionResponse> Handle(UpdateDetentionCommand request, CancellationToken cancellationToken)
        {
            Detention? detention = await _detentionRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _detentionBusinessRules.DetentionShouldExistWhenSelected(detention);
            detention = _mapper.Map(request, detention);

            await _detentionRepository.UpdateAsync(detention!);

            UpdatedDetentionResponse response = _mapper.Map<UpdatedDetentionResponse>(detention);
            return response;
        }
    }
}