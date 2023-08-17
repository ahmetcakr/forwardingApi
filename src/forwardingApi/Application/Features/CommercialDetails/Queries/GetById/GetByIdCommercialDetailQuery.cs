using Application.Features.CommercialDetails.Constants;
using Application.Features.CommercialDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CommercialDetails.Constants.CommercialDetailsOperationClaims;

namespace Application.Features.CommercialDetails.Queries.GetById;

public class GetByIdCommercialDetailQuery : IRequest<GetByIdCommercialDetailResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCommercialDetailQueryHandler : IRequestHandler<GetByIdCommercialDetailQuery, GetByIdCommercialDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommercialDetailRepository _commercialDetailRepository;
        private readonly CommercialDetailBusinessRules _commercialDetailBusinessRules;

        public GetByIdCommercialDetailQueryHandler(IMapper mapper, ICommercialDetailRepository commercialDetailRepository, CommercialDetailBusinessRules commercialDetailBusinessRules)
        {
            _mapper = mapper;
            _commercialDetailRepository = commercialDetailRepository;
            _commercialDetailBusinessRules = commercialDetailBusinessRules;
        }

        public async Task<GetByIdCommercialDetailResponse> Handle(GetByIdCommercialDetailQuery request, CancellationToken cancellationToken)
        {
            CommercialDetail? commercialDetail = await _commercialDetailRepository.GetAsync(predicate: cd => cd.Id == request.Id, cancellationToken: cancellationToken);
            await _commercialDetailBusinessRules.CommercialDetailShouldExistWhenSelected(commercialDetail);

            GetByIdCommercialDetailResponse response = _mapper.Map<GetByIdCommercialDetailResponse>(commercialDetail);
            return response;
        }
    }
}