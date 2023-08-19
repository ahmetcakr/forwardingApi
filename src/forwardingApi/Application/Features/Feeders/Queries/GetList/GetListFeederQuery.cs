using Application.Features.Feeders.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Feeders.Constants.FeedersOperationClaims;

namespace Application.Features.Feeders.Queries.GetList;

public class GetListFeederQuery : IRequest<GetListResponse<GetListFeederListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListFeederQueryHandler : IRequestHandler<GetListFeederQuery, GetListResponse<GetListFeederListItemDto>>
    {
        private readonly IFeederRepository _feederRepository;
        private readonly IMapper _mapper;

        public GetListFeederQueryHandler(IFeederRepository feederRepository, IMapper mapper)
        {
            _feederRepository = feederRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFeederListItemDto>> Handle(GetListFeederQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Feeder> feeders = await _feederRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFeederListItemDto> response = _mapper.Map<GetListResponse<GetListFeederListItemDto>>(feeders);
            return response;
        }
    }
}