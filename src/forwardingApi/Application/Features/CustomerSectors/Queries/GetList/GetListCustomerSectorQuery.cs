using Application.Features.CustomerSectors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerSectors.Constants.CustomerSectorsOperationClaims;

namespace Application.Features.CustomerSectors.Queries.GetList;

public class GetListCustomerSectorQuery : IRequest<GetListResponse<GetListCustomerSectorListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCustomerSectorQueryHandler : IRequestHandler<GetListCustomerSectorQuery, GetListResponse<GetListCustomerSectorListItemDto>>
    {
        private readonly ICustomerSectorRepository _customerSectorRepository;
        private readonly IMapper _mapper;

        public GetListCustomerSectorQueryHandler(ICustomerSectorRepository customerSectorRepository, IMapper mapper)
        {
            _customerSectorRepository = customerSectorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerSectorListItemDto>> Handle(GetListCustomerSectorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerSector> customerSectors = await _customerSectorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerSectorListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerSectorListItemDto>>(customerSectors);
            return response;
        }
    }
}