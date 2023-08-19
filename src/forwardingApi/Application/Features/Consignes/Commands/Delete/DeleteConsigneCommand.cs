using Application.Features.Consignes.Constants;
using Application.Features.Consignes.Constants;
using Application.Features.Consignes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Consignes.Constants.ConsignesOperationClaims;

namespace Application.Features.Consignes.Commands.Delete;

public class DeleteConsigneCommand : IRequest<DeletedConsigneResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ConsignesOperationClaims.Delete };

    public class DeleteConsigneCommandHandler : IRequestHandler<DeleteConsigneCommand, DeletedConsigneResponse>
    {
        private readonly IMapper _mapper;
        private readonly IConsigneRepository _consigneRepository;
        private readonly ConsigneBusinessRules _consigneBusinessRules;

        public DeleteConsigneCommandHandler(IMapper mapper, IConsigneRepository consigneRepository,
                                         ConsigneBusinessRules consigneBusinessRules)
        {
            _mapper = mapper;
            _consigneRepository = consigneRepository;
            _consigneBusinessRules = consigneBusinessRules;
        }

        public async Task<DeletedConsigneResponse> Handle(DeleteConsigneCommand request, CancellationToken cancellationToken)
        {
            Consigne? consigne = await _consigneRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _consigneBusinessRules.ConsigneShouldExistWhenSelected(consigne);

            await _consigneRepository.DeleteAsync(consigne!);

            DeletedConsigneResponse response = _mapper.Map<DeletedConsigneResponse>(consigne);
            return response;
        }
    }
}