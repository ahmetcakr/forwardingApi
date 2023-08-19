using Application.Features.Consignes.Constants;
using Application.Features.Consignes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Consignes.Constants.ConsignesOperationClaims;

namespace Application.Features.Consignes.Commands.Update;

public class UpdateConsigneCommand : IRequest<UpdatedConsigneResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public string[] Roles => new[] { Admin, Write, ConsignesOperationClaims.Update };

    public class UpdateConsigneCommandHandler : IRequestHandler<UpdateConsigneCommand, UpdatedConsigneResponse>
    {
        private readonly IMapper _mapper;
        private readonly IConsigneRepository _consigneRepository;
        private readonly ConsigneBusinessRules _consigneBusinessRules;

        public UpdateConsigneCommandHandler(IMapper mapper, IConsigneRepository consigneRepository,
                                         ConsigneBusinessRules consigneBusinessRules)
        {
            _mapper = mapper;
            _consigneRepository = consigneRepository;
            _consigneBusinessRules = consigneBusinessRules;
        }

        public async Task<UpdatedConsigneResponse> Handle(UpdateConsigneCommand request, CancellationToken cancellationToken)
        {
            Consigne? consigne = await _consigneRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _consigneBusinessRules.ConsigneShouldExistWhenSelected(consigne);
            consigne = _mapper.Map(request, consigne);

            await _consigneRepository.UpdateAsync(consigne!);

            UpdatedConsigneResponse response = _mapper.Map<UpdatedConsigneResponse>(consigne);
            return response;
        }
    }
}