using Application.Features.Detentions.Constants;
using Application.Features.Detentions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Detentions.Constants.DetentionsOperationClaims;

namespace Application.Features.Detentions.Commands.Create;

public class CreateDetentionCommand : IRequest<CreatedDetentionResponse>, ISecuredRequest, ITransactionalRequest
{
    public int? Day { get; set; }
    public int? Fee { get; set; }

    public string[] Roles => new[] { Admin, Write, DetentionsOperationClaims.Create };

    public class CreateDetentionCommandHandler : IRequestHandler<CreateDetentionCommand, CreatedDetentionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDetentionRepository _detentionRepository;
        private readonly DetentionBusinessRules _detentionBusinessRules;

        public CreateDetentionCommandHandler(IMapper mapper, IDetentionRepository detentionRepository,
                                         DetentionBusinessRules detentionBusinessRules)
        {
            _mapper = mapper;
            _detentionRepository = detentionRepository;
            _detentionBusinessRules = detentionBusinessRules;
        }

        public async Task<CreatedDetentionResponse> Handle(CreateDetentionCommand request, CancellationToken cancellationToken)
        {
            Detention detention = _mapper.Map<Detention>(request);

            await _detentionRepository.AddAsync(detention);

            CreatedDetentionResponse response = _mapper.Map<CreatedDetentionResponse>(detention);
            return response;
        }
    }
}