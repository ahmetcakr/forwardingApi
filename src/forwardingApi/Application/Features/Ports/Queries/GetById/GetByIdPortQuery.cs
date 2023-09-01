using Application.Features.Ports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Ports.Queries.GetById;

public class GetByIdPortQuery : IRequest<GetByIdPortResponse>
{
    public int Id { get; set; }

    public class GetByIdPortQueryHandler : IRequestHandler<GetByIdPortQuery, GetByIdPortResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortRepository _portRepository;
        private readonly PortBusinessRules _portBusinessRules;

        public GetByIdPortQueryHandler(IMapper mapper, IPortRepository portRepository, PortBusinessRules portBusinessRules)
        {
            _mapper = mapper;
            _portRepository = portRepository;
            _portBusinessRules = portBusinessRules;
        }

        public async Task<GetByIdPortResponse> Handle(GetByIdPortQuery request, CancellationToken cancellationToken)
        {
            Port? port = await _portRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _portBusinessRules.PortShouldExistWhenSelected(port);

            GetByIdPortResponse response = _mapper.Map<GetByIdPortResponse>(port);
            return response;
        }
    }
}