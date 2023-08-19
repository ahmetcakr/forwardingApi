using Application.Features.Consignes.Constants;
using Application.Features.Consignes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Consignes.Constants.ConsignesOperationClaims;

namespace Application.Features.Consignes.Queries.GetById;

public class GetByIdConsigneQuery : IRequest<GetByIdConsigneResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdConsigneQueryHandler : IRequestHandler<GetByIdConsigneQuery, GetByIdConsigneResponse>
    {
        private readonly IMapper _mapper;
        private readonly IConsigneRepository _consigneRepository;
        private readonly ConsigneBusinessRules _consigneBusinessRules;

        public GetByIdConsigneQueryHandler(IMapper mapper, IConsigneRepository consigneRepository, ConsigneBusinessRules consigneBusinessRules)
        {
            _mapper = mapper;
            _consigneRepository = consigneRepository;
            _consigneBusinessRules = consigneBusinessRules;
        }

        public async Task<GetByIdConsigneResponse> Handle(GetByIdConsigneQuery request, CancellationToken cancellationToken)
        {
            Consigne? consigne = await _consigneRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _consigneBusinessRules.ConsigneShouldExistWhenSelected(consigne);

            GetByIdConsigneResponse response = _mapper.Map<GetByIdConsigneResponse>(consigne);
            return response;
        }
    }
}