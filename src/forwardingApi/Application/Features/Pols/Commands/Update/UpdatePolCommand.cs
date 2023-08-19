using Application.Features.Pols.Constants;
using Application.Features.Pols.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Pols.Constants.PolsOperationClaims;

namespace Application.Features.Pols.Commands.Update;

public class UpdatePolCommand : IRequest<UpdatedPolResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string PolName { get; set; }

    public string[] Roles => new[] { Admin, Write, PolsOperationClaims.Update };

    public class UpdatePolCommandHandler : IRequestHandler<UpdatePolCommand, UpdatedPolResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPolRepository _polRepository;
        private readonly PolBusinessRules _polBusinessRules;

        public UpdatePolCommandHandler(IMapper mapper, IPolRepository polRepository,
                                         PolBusinessRules polBusinessRules)
        {
            _mapper = mapper;
            _polRepository = polRepository;
            _polBusinessRules = polBusinessRules;
        }

        public async Task<UpdatedPolResponse> Handle(UpdatePolCommand request, CancellationToken cancellationToken)
        {
            Pol? pol = await _polRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _polBusinessRules.PolShouldExistWhenSelected(pol);
            pol = _mapper.Map(request, pol);

            await _polRepository.UpdateAsync(pol!);

            UpdatedPolResponse response = _mapper.Map<UpdatedPolResponse>(pol);
            return response;
        }
    }
}