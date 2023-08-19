using Application.Features.TotalFees.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.TotalFees.Constants.TotalFeesOperationClaims;

namespace Application.Features.TotalFees.Queries.GetList;

public class GetListTotalFeeQuery : IRequest<GetListResponse<GetListTotalFeeListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListTotalFeeQueryHandler : IRequestHandler<GetListTotalFeeQuery, GetListResponse<GetListTotalFeeListItemDto>>
    {
        private readonly ITotalFeeRepository _totalFeeRepository;
        private readonly IMapper _mapper;

        public GetListTotalFeeQueryHandler(ITotalFeeRepository totalFeeRepository, IMapper mapper)
        {
            _totalFeeRepository = totalFeeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTotalFeeListItemDto>> Handle(GetListTotalFeeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TotalFee> totalFees = await _totalFeeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTotalFeeListItemDto> response = _mapper.Map<GetListResponse<GetListTotalFeeListItemDto>>(totalFees);
            return response;
        }
    }
}