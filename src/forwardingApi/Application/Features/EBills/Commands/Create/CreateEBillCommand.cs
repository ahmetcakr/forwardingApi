using Application.Features.EBills.Constants;
using Application.Features.EBills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.EBills.Constants.EBillsOperationClaims;

namespace Application.Features.EBills.Commands.Create;

public class CreateEBillCommand : IRequest<CreatedEBillResponse>, ISecuredRequest, ITransactionalRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Mail { get; set; }

    public string[] Roles => new[] { Admin, Write, EBillsOperationClaims.Create };

    public class CreateEBillCommandHandler : IRequestHandler<CreateEBillCommand, CreatedEBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEBillRepository _eBillRepository;
        private readonly EBillBusinessRules _eBillBusinessRules;

        public CreateEBillCommandHandler(IMapper mapper, IEBillRepository eBillRepository,
                                         EBillBusinessRules eBillBusinessRules)
        {
            _mapper = mapper;
            _eBillRepository = eBillRepository;
            _eBillBusinessRules = eBillBusinessRules;
        }

        public async Task<CreatedEBillResponse> Handle(CreateEBillCommand request, CancellationToken cancellationToken)
        {
            EBill eBill = _mapper.Map<EBill>(request);

            await _eBillRepository.AddAsync(eBill);

            CreatedEBillResponse response = _mapper.Map<CreatedEBillResponse>(eBill);
            return response;
        }
    }
}