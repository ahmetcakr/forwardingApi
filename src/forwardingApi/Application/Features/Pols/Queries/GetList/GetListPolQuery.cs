using Application.Features.Pols.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Pols.Constants.PolsOperationClaims;

namespace Application.Features.Pols.Queries.GetList;

public class GetListPolQuery : IRequest<GetListResponse<GetListPolListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListPolQueryHandler : IRequestHandler<GetListPolQuery, GetListResponse<GetListPolListItemDto>>
    {
        private readonly IPolRepository _polRepository;
        private readonly IMapper _mapper;

        public GetListPolQueryHandler(IPolRepository polRepository, IMapper mapper)
        {
            _polRepository = polRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPolListItemDto>> Handle(GetListPolQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Pol> pols = await _polRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPolListItemDto> response = _mapper.Map<GetListResponse<GetListPolListItemDto>>(pols);
            return response;
        }
    }
}