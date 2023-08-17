using Application.Features.CommercialDetails.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CommercialDetails.Constants.CommercialDetailsOperationClaims;

namespace Application.Features.CommercialDetails.Queries.GetList;

public class GetListCommercialDetailQuery : IRequest<GetListResponse<GetListCommercialDetailListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCommercialDetails({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCommercialDetails";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCommercialDetailQueryHandler : IRequestHandler<GetListCommercialDetailQuery, GetListResponse<GetListCommercialDetailListItemDto>>
    {
        private readonly ICommercialDetailRepository _commercialDetailRepository;
        private readonly IMapper _mapper;

        public GetListCommercialDetailQueryHandler(ICommercialDetailRepository commercialDetailRepository, IMapper mapper)
        {
            _commercialDetailRepository = commercialDetailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCommercialDetailListItemDto>> Handle(GetListCommercialDetailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CommercialDetail> commercialDetails = await _commercialDetailRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCommercialDetailListItemDto> response = _mapper.Map<GetListResponse<GetListCommercialDetailListItemDto>>(commercialDetails);
            return response;
        }
    }
}