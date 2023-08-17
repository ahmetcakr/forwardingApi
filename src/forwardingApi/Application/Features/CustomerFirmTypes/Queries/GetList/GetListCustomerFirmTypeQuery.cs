using Application.Features.CustomerFirmTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerFirmTypes.Constants.CustomerFirmTypesOperationClaims;

namespace Application.Features.CustomerFirmTypes.Queries.GetList;

public class GetListCustomerFirmTypeQuery : IRequest<GetListResponse<GetListCustomerFirmTypeListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCustomerFirmTypeQueryHandler : IRequestHandler<GetListCustomerFirmTypeQuery, GetListResponse<GetListCustomerFirmTypeListItemDto>>
    {
        private readonly ICustomerFirmTypeRepository _customerFirmTypeRepository;
        private readonly IMapper _mapper;

        public GetListCustomerFirmTypeQueryHandler(ICustomerFirmTypeRepository customerFirmTypeRepository, IMapper mapper)
        {
            _customerFirmTypeRepository = customerFirmTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerFirmTypeListItemDto>> Handle(GetListCustomerFirmTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerFirmType> customerFirmTypes = await _customerFirmTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerFirmTypeListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerFirmTypeListItemDto>>(customerFirmTypes);
            return response;
        }
    }
}