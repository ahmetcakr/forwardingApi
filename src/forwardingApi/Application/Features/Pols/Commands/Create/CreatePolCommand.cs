using Application.Features.Pols.Constants;
using Application.Features.Pols.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Pols.Constants.PolsOperationClaims;

namespace Application.Features.Pols.Commands.Create;

public class CreatePolCommand : IRequest<CreatedPolResponse>, ISecuredRequest, ITransactionalRequest
{
    public string PolName { get; set; }

    public string[] Roles => new[] { Admin, Write, PolsOperationClaims.Create };

    public class CreatePolCommandHandler : IRequestHandler<CreatePolCommand, CreatedPolResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPolRepository _polRepository;
        private readonly PolBusinessRules _polBusinessRules;

        public CreatePolCommandHandler(IMapper mapper, IPolRepository polRepository,
                                         PolBusinessRules polBusinessRules)
        {
            _mapper = mapper;
            _polRepository = polRepository;
            _polBusinessRules = polBusinessRules;
        }

        public async Task<CreatedPolResponse> Handle(CreatePolCommand request, CancellationToken cancellationToken)
        {
            Pol pol = _mapper.Map<Pol>(request);

            await _polRepository.AddAsync(pol);

            CreatedPolResponse response = _mapper.Map<CreatedPolResponse>(pol);
            return response;
        }
    }
}