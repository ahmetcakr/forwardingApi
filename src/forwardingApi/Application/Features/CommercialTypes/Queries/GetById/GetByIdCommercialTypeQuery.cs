using Application.Features.CommercialTypes.Constants;
using Application.Features.CommercialTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CommercialTypes.Constants.CommercialTypesOperationClaims;

namespace Application.Features.CommercialTypes.Queries.GetById;

public class GetByIdCommercialTypeQuery : IRequest<GetByIdCommercialTypeResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCommercialTypeQueryHandler : IRequestHandler<GetByIdCommercialTypeQuery, GetByIdCommercialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommercialTypeRepository _commercialTypeRepository;
        private readonly CommercialTypeBusinessRules _commercialTypeBusinessRules;

        public GetByIdCommercialTypeQueryHandler(IMapper mapper, ICommercialTypeRepository commercialTypeRepository, CommercialTypeBusinessRules commercialTypeBusinessRules)
        {
            _mapper = mapper;
            _commercialTypeRepository = commercialTypeRepository;
            _commercialTypeBusinessRules = commercialTypeBusinessRules;
        }

        public async Task<GetByIdCommercialTypeResponse> Handle(GetByIdCommercialTypeQuery request, CancellationToken cancellationToken)
        {
            CommercialType? commercialType = await _commercialTypeRepository.GetAsync(predicate: ct => ct.Id == request.Id, cancellationToken: cancellationToken);
            await _commercialTypeBusinessRules.CommercialTypeShouldExistWhenSelected(commercialType);

            GetByIdCommercialTypeResponse response = _mapper.Map<GetByIdCommercialTypeResponse>(commercialType);
            return response;
        }
    }
}