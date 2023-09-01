using Application.Features.Ports.Constants;
using Application.Features.Ports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Ports.Commands.Delete;

public class DeletePortCommand : IRequest<DeletedPortResponse>, ITransactionalRequest
{
    public int Id { get; set; }

    public class DeletePortCommandHandler : IRequestHandler<DeletePortCommand, DeletedPortResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortRepository _portRepository;
        private readonly PortBusinessRules _portBusinessRules;

        public DeletePortCommandHandler(IMapper mapper, IPortRepository portRepository,
                                         PortBusinessRules portBusinessRules)
        {
            _mapper = mapper;
            _portRepository = portRepository;
            _portBusinessRules = portBusinessRules;
        }

        public async Task<DeletedPortResponse> Handle(DeletePortCommand request, CancellationToken cancellationToken)
        {
            Port? port = await _portRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _portBusinessRules.PortShouldExistWhenSelected(port);

            await _portRepository.DeleteAsync(port!);

            DeletedPortResponse response = _mapper.Map<DeletedPortResponse>(port);
            return response;
        }
    }
}