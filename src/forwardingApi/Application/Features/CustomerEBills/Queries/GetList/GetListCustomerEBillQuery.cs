using Application.Features.CustomerEBills.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerEBills.Constants.CustomerEBillsOperationClaims;

namespace Application.Features.CustomerEBills.Queries.GetList;

public class GetListCustomerEBillQuery : IRequest<GetListResponse<GetListCustomerEBillListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCustomerEBillQueryHandler : IRequestHandler<GetListCustomerEBillQuery, GetListResponse<GetListCustomerEBillListItemDto>>
    {
        private readonly ICustomerEBillRepository _customerEBillRepository;
        private readonly IMapper _mapper;

        public GetListCustomerEBillQueryHandler(ICustomerEBillRepository customerEBillRepository, IMapper mapper)
        {
            _customerEBillRepository = customerEBillRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerEBillListItemDto>> Handle(GetListCustomerEBillQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerEBill> customerEBills = await _customerEBillRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerEBillListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerEBillListItemDto>>(customerEBills);
            return response;
        }
    }
}