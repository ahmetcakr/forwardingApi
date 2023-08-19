using Application.Features.Pods.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Pods;

public class PodsManager : IPodsService
{
    private readonly IPodRepository _podRepository;
    private readonly PodBusinessRules _podBusinessRules;

    public PodsManager(IPodRepository podRepository, PodBusinessRules podBusinessRules)
    {
        _podRepository = podRepository;
        _podBusinessRules = podBusinessRules;
    }

    public async Task<Pod?> GetAsync(
        Expression<Func<Pod, bool>> predicate,
        Func<IQueryable<Pod>, IIncludableQueryable<Pod, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Pod? pod = await _podRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return pod;
    }

    public async Task<IPaginate<Pod>?> GetListAsync(
        Expression<Func<Pod, bool>>? predicate = null,
        Func<IQueryable<Pod>, IOrderedQueryable<Pod>>? orderBy = null,
        Func<IQueryable<Pod>, IIncludableQueryable<Pod, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Pod> podList = await _podRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return podList;
    }

    public async Task<Pod> AddAsync(Pod pod)
    {
        Pod addedPod = await _podRepository.AddAsync(pod);

        return addedPod;
    }

    public async Task<Pod> UpdateAsync(Pod pod)
    {
        Pod updatedPod = await _podRepository.UpdateAsync(pod);

        return updatedPod;
    }

    public async Task<Pod> DeleteAsync(Pod pod, bool permanent = false)
    {
        Pod deletedPod = await _podRepository.DeleteAsync(pod);

        return deletedPod;
    }
}
