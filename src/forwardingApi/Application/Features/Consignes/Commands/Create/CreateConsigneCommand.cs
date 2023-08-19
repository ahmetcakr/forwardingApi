using Application.Features.Consignes.Constants;
using Application.Features.Consignes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Consignes.Constants.ConsignesOperationClaims;

namespace Application.Features.Consignes.Commands.Create;

public class CreateConsigneCommand : IRequest<CreatedConsigneResponse>, ISecuredRequest, ITransactionalRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public string[] Roles => new[] { Admin, Write, ConsignesOperationClaims.Create };

    public class CreateConsigneCommandHandler : IRequestHandler<CreateConsigneCommand, CreatedConsigneResponse>
    {
        private readonly IMapper _mapper;
        private readonly IConsigneRepository _consigneRepository;
        private readonly ConsigneBusinessRules _consigneBusinessRules;

        public CreateConsigneCommandHandler(IMapper mapper, IConsigneRepository consigneRepository,
                                         ConsigneBusinessRules consigneBusinessRules)
        {
            _mapper = mapper;
            _consigneRepository = consigneRepository;
            _consigneBusinessRules = consigneBusinessRules;
        }

        public async Task<CreatedConsigneResponse> Handle(CreateConsigneCommand request, CancellationToken cancellationToken)
        {
            Consigne consigne = _mapper.Map<Consigne>(request);

            await _consigneRepository.AddAsync(consigne);

            CreatedConsigneResponse response = _mapper.Map<CreatedConsigneResponse>(consigne);
            return response;
        }
    }
}