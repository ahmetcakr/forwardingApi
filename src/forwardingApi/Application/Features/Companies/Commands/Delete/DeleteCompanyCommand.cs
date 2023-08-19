using Application.Features.Companies.Constants;
using Application.Features.Companies.Constants;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Companies.Constants.CompaniesOperationClaims;

namespace Application.Features.Companies.Commands.Delete;

public class DeleteCompanyCommand : IRequest<DeletedCompanyResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CompaniesOperationClaims.Delete };

    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, DeletedCompanyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyBusinessRules _companyBusinessRules;

        public DeleteCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository,
                                         CompanyBusinessRules companyBusinessRules)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _companyBusinessRules = companyBusinessRules;
        }

        public async Task<DeletedCompanyResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            Company? company = await _companyRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _companyBusinessRules.CompanyShouldExistWhenSelected(company);

            await _companyRepository.DeleteAsync(company!);

            DeletedCompanyResponse response = _mapper.Map<DeletedCompanyResponse>(company);
            return response;
        }
    }
}