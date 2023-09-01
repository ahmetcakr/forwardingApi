using Application.Features.Ports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Ports.Commands.Update;

public class UpdatePortCommand : IRequest<UpdatedPortResponse>, ICacheRemoverRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string PortName { get; set; }
    public string PortCode { get; set; }
    public string CountryCode { get; set; }
    public string CountryName { get; set; }
    public string Region { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPorts";

    public class UpdatePortCommandHandler : IRequestHandler<UpdatePortCommand, UpdatedPortResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortRepository _portRepository;
        private readonly PortBusinessRules _portBusinessRules;

        public UpdatePortCommandHandler(IMapper mapper, IPortRepository portRepository,
                                         PortBusinessRules portBusinessRules)
        {
            _mapper = mapper;
            _portRepository = portRepository;
            _portBusinessRules = portBusinessRules;
        }

        public async Task<UpdatedPortResponse> Handle(UpdatePortCommand request, CancellationToken cancellationToken)
        {
            Port? port = await _portRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _portBusinessRules.PortShouldExistWhenSelected(port);
            port = _mapper.Map(request, port);

            await _portRepository.UpdateAsync(port!);

            UpdatedPortResponse response = _mapper.Map<UpdatedPortResponse>(port);
            return response;
        }
    }
}