using Application.Features.Pols.Constants;
using Application.Features.Pols.Constants;
using Application.Features.Pols.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Pols.Constants.PolsOperationClaims;

namespace Application.Features.Pols.Commands.Delete;

public class DeletePolCommand : IRequest<DeletedPolResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, PolsOperationClaims.Delete };

    public class DeletePolCommandHandler : IRequestHandler<DeletePolCommand, DeletedPolResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPolRepository _polRepository;
        private readonly PolBusinessRules _polBusinessRules;

        public DeletePolCommandHandler(IMapper mapper, IPolRepository polRepository,
                                         PolBusinessRules polBusinessRules)
        {
            _mapper = mapper;
            _polRepository = polRepository;
            _polBusinessRules = polBusinessRules;
        }

        public async Task<DeletedPolResponse> Handle(DeletePolCommand request, CancellationToken cancellationToken)
        {
            Pol? pol = await _polRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _polBusinessRules.PolShouldExistWhenSelected(pol);

            await _polRepository.DeleteAsync(pol!);

            DeletedPolResponse response = _mapper.Map<DeletedPolResponse>(pol);
            return response;
        }
    }
}