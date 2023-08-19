using Application.Features.Demurrages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Demurrages.Constants.DemurragesOperationClaims;

namespace Application.Features.Demurrages.Queries.GetList;

public class GetListDemurrageQuery : IRequest<GetListResponse<GetListDemurrageListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListDemurrageQueryHandler : IRequestHandler<GetListDemurrageQuery, GetListResponse<GetListDemurrageListItemDto>>
    {
        private readonly IDemurrageRepository _demurrageRepository;
        private readonly IMapper _mapper;

        public GetListDemurrageQueryHandler(IDemurrageRepository demurrageRepository, IMapper mapper)
        {
            _demurrageRepository = demurrageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDemurrageListItemDto>> Handle(GetListDemurrageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Demurrage> demurrages = await _demurrageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDemurrageListItemDto> response = _mapper.Map<GetListResponse<GetListDemurrageListItemDto>>(demurrages);
            return response;
        }
    }
}