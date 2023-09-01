using Application.Features.Ports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Ports.Commands.Create;

public class CreatePortCommand : IRequest<CreatedPortResponse>, ICacheRemoverRequest, ITransactionalRequest
{
    public string PortName { get; set; }
    public string PortCode { get; set; }
    public string CountryCode { get; set; }
    public string CountryName { get; set; }
    public string Region { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPorts";

    public class CreatePortCommandHandler : IRequestHandler<CreatePortCommand, CreatedPortResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortRepository _portRepository;
        private readonly PortBusinessRules _portBusinessRules;

        public CreatePortCommandHandler(IMapper mapper, IPortRepository portRepository,
                                         PortBusinessRules portBusinessRules)
        {
            _mapper = mapper;
            _portRepository = portRepository;
            _portBusinessRules = portBusinessRules;
        }

        public async Task<CreatedPortResponse> Handle(CreatePortCommand request, CancellationToken cancellationToken)
        {
            Port port = _mapper.Map<Port>(request);

            await _portRepository.AddAsync(port);

            CreatedPortResponse response = _mapper.Map<CreatedPortResponse>(port);
            return response;
        }
    }
}