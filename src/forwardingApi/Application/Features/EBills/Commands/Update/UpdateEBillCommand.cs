using Application.Features.EBills.Constants;
using Application.Features.EBills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.EBills.Constants.EBillsOperationClaims;

namespace Application.Features.EBills.Commands.Update;

public class UpdateEBillCommand : IRequest<UpdatedEBillResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Mail { get; set; }

    public string[] Roles => new[] { Admin, Write, EBillsOperationClaims.Update };

    public class UpdateEBillCommandHandler : IRequestHandler<UpdateEBillCommand, UpdatedEBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEBillRepository _eBillRepository;
        private readonly EBillBusinessRules _eBillBusinessRules;

        public UpdateEBillCommandHandler(IMapper mapper, IEBillRepository eBillRepository,
                                         EBillBusinessRules eBillBusinessRules)
        {
            _mapper = mapper;
            _eBillRepository = eBillRepository;
            _eBillBusinessRules = eBillBusinessRules;
        }

        public async Task<UpdatedEBillResponse> Handle(UpdateEBillCommand request, CancellationToken cancellationToken)
        {
            EBill? eBill = await _eBillRepository.GetAsync(predicate: eb => eb.Id == request.Id, cancellationToken: cancellationToken);
            await _eBillBusinessRules.EBillShouldExistWhenSelected(eBill);
            eBill = _mapper.Map(request, eBill);

            await _eBillRepository.UpdateAsync(eBill!);

            UpdatedEBillResponse response = _mapper.Map<UpdatedEBillResponse>(eBill);
            return response;
        }
    }
}