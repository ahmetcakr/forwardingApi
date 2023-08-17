using Application.Features.EBills.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.EBills.Constants.EBillsOperationClaims;

namespace Application.Features.EBills.Queries.GetList;

public class GetListEBillQuery : IRequest<GetListResponse<GetListEBillListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListEBillQueryHandler : IRequestHandler<GetListEBillQuery, GetListResponse<GetListEBillListItemDto>>
    {
        private readonly IEBillRepository _eBillRepository;
        private readonly IMapper _mapper;

        public GetListEBillQueryHandler(IEBillRepository eBillRepository, IMapper mapper)
        {
            _eBillRepository = eBillRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEBillListItemDto>> Handle(GetListEBillQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EBill> eBills = await _eBillRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEBillListItemDto> response = _mapper.Map<GetListResponse<GetListEBillListItemDto>>(eBills);
            return response;
        }
    }
}