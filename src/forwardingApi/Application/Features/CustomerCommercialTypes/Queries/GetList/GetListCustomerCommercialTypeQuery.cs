using Application.Features.CustomerCommercialTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerCommercialTypes.Constants.CustomerCommercialTypesOperationClaims;

namespace Application.Features.CustomerCommercialTypes.Queries.GetList;

public class GetListCustomerCommercialTypeQuery : IRequest<GetListResponse<GetListCustomerCommercialTypeListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCustomerCommercialTypeQueryHandler : IRequestHandler<GetListCustomerCommercialTypeQuery, GetListResponse<GetListCustomerCommercialTypeListItemDto>>
    {
        private readonly ICustomerCommercialTypeRepository _customerCommercialTypeRepository;
        private readonly IMapper _mapper;

        public GetListCustomerCommercialTypeQueryHandler(ICustomerCommercialTypeRepository customerCommercialTypeRepository, IMapper mapper)
        {
            _customerCommercialTypeRepository = customerCommercialTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerCommercialTypeListItemDto>> Handle(GetListCustomerCommercialTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerCommercialType> customerCommercialTypes = await _customerCommercialTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerCommercialTypeListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerCommercialTypeListItemDto>>(customerCommercialTypes);
            return response;
        }
    }
}