using Application.Features.EBills.Constants;
using Application.Features.EBills.Constants;
using Application.Features.EBills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.EBills.Constants.EBillsOperationClaims;

namespace Application.Features.EBills.Commands.Delete;

public class DeleteEBillCommand : IRequest<DeletedEBillResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, EBillsOperationClaims.Delete };

    public class DeleteEBillCommandHandler : IRequestHandler<DeleteEBillCommand, DeletedEBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEBillRepository _eBillRepository;
        private readonly EBillBusinessRules _eBillBusinessRules;

        public DeleteEBillCommandHandler(IMapper mapper, IEBillRepository eBillRepository,
                                         EBillBusinessRules eBillBusinessRules)
        {
            _mapper = mapper;
            _eBillRepository = eBillRepository;
            _eBillBusinessRules = eBillBusinessRules;
        }

        public async Task<DeletedEBillResponse> Handle(DeleteEBillCommand request, CancellationToken cancellationToken)
        {
            EBill? eBill = await _eBillRepository.GetAsync(predicate: eb => eb.Id == request.Id, cancellationToken: cancellationToken);
            await _eBillBusinessRules.EBillShouldExistWhenSelected(eBill);

            await _eBillRepository.DeleteAsync(eBill!);

            DeletedEBillResponse response = _mapper.Map<DeletedEBillResponse>(eBill);
            return response;
        }
    }
}