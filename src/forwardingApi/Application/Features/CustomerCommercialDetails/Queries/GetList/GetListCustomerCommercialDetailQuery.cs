using Application.Features.CustomerCommercialDetails.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerCommercialDetails.Constants.CustomerCommercialDetailsOperationClaims;

namespace Application.Features.CustomerCommercialDetails.Queries.GetList;

public class GetListCustomerCommercialDetailQuery : IRequest<GetListResponse<GetListCustomerCommercialDetailListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCustomerCommercialDetailQueryHandler : IRequestHandler<GetListCustomerCommercialDetailQuery, GetListResponse<GetListCustomerCommercialDetailListItemDto>>
    {
        private readonly ICustomerCommercialDetailRepository _customerCommercialDetailRepository;
        private readonly IMapper _mapper;

        public GetListCustomerCommercialDetailQueryHandler(ICustomerCommercialDetailRepository customerCommercialDetailRepository, IMapper mapper)
        {
            _customerCommercialDetailRepository = customerCommercialDetailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerCommercialDetailListItemDto>> Handle(GetListCustomerCommercialDetailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerCommercialDetail> customerCommercialDetails = await _customerCommercialDetailRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerCommercialDetailListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerCommercialDetailListItemDto>>(customerCommercialDetails);
            return response;
        }
    }
}