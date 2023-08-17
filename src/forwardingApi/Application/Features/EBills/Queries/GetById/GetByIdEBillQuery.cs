using Application.Features.EBills.Constants;
using Application.Features.EBills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.EBills.Constants.EBillsOperationClaims;

namespace Application.Features.EBills.Queries.GetById;

public class GetByIdEBillQuery : IRequest<GetByIdEBillResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdEBillQueryHandler : IRequestHandler<GetByIdEBillQuery, GetByIdEBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEBillRepository _eBillRepository;
        private readonly EBillBusinessRules _eBillBusinessRules;

        public GetByIdEBillQueryHandler(IMapper mapper, IEBillRepository eBillRepository, EBillBusinessRules eBillBusinessRules)
        {
            _mapper = mapper;
            _eBillRepository = eBillRepository;
            _eBillBusinessRules = eBillBusinessRules;
        }

        public async Task<GetByIdEBillResponse> Handle(GetByIdEBillQuery request, CancellationToken cancellationToken)
        {
            EBill? eBill = await _eBillRepository.GetAsync(predicate: eb => eb.Id == request.Id, cancellationToken: cancellationToken);
            await _eBillBusinessRules.EBillShouldExistWhenSelected(eBill);

            GetByIdEBillResponse response = _mapper.Map<GetByIdEBillResponse>(eBill);
            return response;
        }
    }
}