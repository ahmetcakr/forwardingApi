using Application.Features.FreeDays.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.FreeDays.Constants.FreeDaysOperationClaims;

namespace Application.Features.FreeDays.Queries.GetList;

public class GetListFreeDayQuery : IRequest<GetListResponse<GetListFreeDayListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListFreeDayQueryHandler : IRequestHandler<GetListFreeDayQuery, GetListResponse<GetListFreeDayListItemDto>>
    {
        private readonly IFreeDayRepository _freeDayRepository;
        private readonly IMapper _mapper;

        public GetListFreeDayQueryHandler(IFreeDayRepository freeDayRepository, IMapper mapper)
        {
            _freeDayRepository = freeDayRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFreeDayListItemDto>> Handle(GetListFreeDayQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FreeDay> freeDays = await _freeDayRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFreeDayListItemDto> response = _mapper.Map<GetListResponse<GetListFreeDayListItemDto>>(freeDays);
            return response;
        }
    }
}