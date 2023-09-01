using Application.Features.Ports.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ports;

public class PortsManager : IPortsService
{
    private readonly IPortRepository _portRepository;
    private readonly PortBusinessRules _portBusinessRules;

    public PortsManager(IPortRepository portRepository, PortBusinessRules portBusinessRules)
    {
        _portRepository = portRepository;
        _portBusinessRules = portBusinessRules;
    }

    public async Task<Port?> GetAsync(
        Expression<Func<Port, bool>> predicate,
        Func<IQueryable<Port>, IIncludableQueryable<Port, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Port? port = await _portRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return port;
    }

    public async Task<IPaginate<Port>?> GetListAsync(
        Expression<Func<Port, bool>>? predicate = null,
        Func<IQueryable<Port>, IOrderedQueryable<Port>>? orderBy = null,
        Func<IQueryable<Port>, IIncludableQueryable<Port, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Port> portList = await _portRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return portList;
    }

    public async Task<Port> AddAsync(Port port)
    {
        Port addedPort = await _portRepository.AddAsync(port);

        return addedPort;
    }

    public async Task<Port> UpdateAsync(Port port)
    {
        Port updatedPort = await _portRepository.UpdateAsync(port);

        return updatedPort;
    }

    public async Task<Port> DeleteAsync(Port port, bool permanent = false)
    {
        Port deletedPort = await _portRepository.DeleteAsync(port);

        return deletedPort;
    }
}
