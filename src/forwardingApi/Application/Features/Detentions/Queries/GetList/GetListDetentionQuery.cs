using Application.Features.Detentions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Detentions.Constants.DetentionsOperationClaims;

namespace Application.Features.Detentions.Queries.GetList;

public class GetListDetentionQuery : IRequest<GetListResponse<GetListDetentionListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListDetentionQueryHandler : IRequestHandler<GetListDetentionQuery, GetListResponse<GetListDetentionListItemDto>>
    {
        private readonly IDetentionRepository _detentionRepository;
        private readonly IMapper _mapper;

        public GetListDetentionQueryHandler(IDetentionRepository detentionRepository, IMapper mapper)
        {
            _detentionRepository = detentionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDetentionListItemDto>> Handle(GetListDetentionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Detention> detentions = await _detentionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDetentionListItemDto> response = _mapper.Map<GetListResponse<GetListDetentionListItemDto>>(detentions);
            return response;
        }
    }
}