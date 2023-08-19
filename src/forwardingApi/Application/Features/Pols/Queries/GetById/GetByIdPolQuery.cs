using Application.Features.Pols.Constants;
using Application.Features.Pols.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Pols.Constants.PolsOperationClaims;

namespace Application.Features.Pols.Queries.GetById;

public class GetByIdPolQuery : IRequest<GetByIdPolResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdPolQueryHandler : IRequestHandler<GetByIdPolQuery, GetByIdPolResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPolRepository _polRepository;
        private readonly PolBusinessRules _polBusinessRules;

        public GetByIdPolQueryHandler(IMapper mapper, IPolRepository polRepository, PolBusinessRules polBusinessRules)
        {
            _mapper = mapper;
            _polRepository = polRepository;
            _polBusinessRules = polBusinessRules;
        }

        public async Task<GetByIdPolResponse> Handle(GetByIdPolQuery request, CancellationToken cancellationToken)
        {
            Pol? pol = await _polRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _polBusinessRules.PolShouldExistWhenSelected(pol);

            GetByIdPolResponse response = _mapper.Map<GetByIdPolResponse>(pol);
            return response;
        }
    }
}