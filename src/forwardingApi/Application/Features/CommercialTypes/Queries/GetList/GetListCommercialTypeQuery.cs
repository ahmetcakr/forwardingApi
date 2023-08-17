using Application.Features.CommercialTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CommercialTypes.Constants.CommercialTypesOperationClaims;

namespace Application.Features.CommercialTypes.Queries.GetList;

public class GetListCommercialTypeQuery : IRequest<GetListResponse<GetListCommercialTypeListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCommercialTypeQueryHandler : IRequestHandler<GetListCommercialTypeQuery, GetListResponse<GetListCommercialTypeListItemDto>>
    {
        private readonly ICommercialTypeRepository _commercialTypeRepository;
        private readonly IMapper _mapper;

        public GetListCommercialTypeQueryHandler(ICommercialTypeRepository commercialTypeRepository, IMapper mapper)
        {
            _commercialTypeRepository = commercialTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCommercialTypeListItemDto>> Handle(GetListCommercialTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CommercialType> commercialTypes = await _commercialTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCommercialTypeListItemDto> response = _mapper.Map<GetListResponse<GetListCommercialTypeListItemDto>>(commercialTypes);
            return response;
        }
    }
}