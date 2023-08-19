using Application.Features.FreeDays.Constants;
using Application.Features.FreeDays.Constants;
using Application.Features.FreeDays.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.FreeDays.Constants.FreeDaysOperationClaims;

namespace Application.Features.FreeDays.Commands.Delete;

public class DeleteFreeDayCommand : IRequest<DeletedFreeDayResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, FreeDaysOperationClaims.Delete };

    public class DeleteFreeDayCommandHandler : IRequestHandler<DeleteFreeDayCommand, DeletedFreeDayResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFreeDayRepository _freeDayRepository;
        private readonly FreeDayBusinessRules _freeDayBusinessRules;

        public DeleteFreeDayCommandHandler(IMapper mapper, IFreeDayRepository freeDayRepository,
                                         FreeDayBusinessRules freeDayBusinessRules)
        {
            _mapper = mapper;
            _freeDayRepository = freeDayRepository;
            _freeDayBusinessRules = freeDayBusinessRules;
        }

        public async Task<DeletedFreeDayResponse> Handle(DeleteFreeDayCommand request, CancellationToken cancellationToken)
        {
            FreeDay? freeDay = await _freeDayRepository.GetAsync(predicate: fd => fd.Id == request.Id, cancellationToken: cancellationToken);
            await _freeDayBusinessRules.FreeDayShouldExistWhenSelected(freeDay);

            await _freeDayRepository.DeleteAsync(freeDay!);

            DeletedFreeDayResponse response = _mapper.Map<DeletedFreeDayResponse>(freeDay);
            return response;
        }
    }
}