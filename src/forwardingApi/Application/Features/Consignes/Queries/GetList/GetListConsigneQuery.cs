using Application.Features.Consignes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Consignes.Constants.ConsignesOperationClaims;

namespace Application.Features.Consignes.Queries.GetList;

public class GetListConsigneQuery : IRequest<GetListResponse<GetListConsigneListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListConsigneQueryHandler : IRequestHandler<GetListConsigneQuery, GetListResponse<GetListConsigneListItemDto>>
    {
        private readonly IConsigneRepository _consigneRepository;
        private readonly IMapper _mapper;

        public GetListConsigneQueryHandler(IConsigneRepository consigneRepository, IMapper mapper)
        {
            _consigneRepository = consigneRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListConsigneListItemDto>> Handle(GetListConsigneQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Consigne> consignes = await _consigneRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListConsigneListItemDto> response = _mapper.Map<GetListResponse<GetListConsigneListItemDto>>(consignes);
            return response;
        }
    }
}