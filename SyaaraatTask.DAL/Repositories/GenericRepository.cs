﻿using Microsoft.EntityFrameworkCore;
using SyaaraatTask.DAL.DataContext;
using SyaaraatTask.DAL.Repositories.IRepositories;
using System.Linq.Expressions;
using TH = System.Threading.Tasks;
namespace SyaaraatTask.DAL.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, new()
{
    private readonly AspNetCoreTasksDbContext _aspNetCoreNTierDbContext;

    public GenericRepository(AspNetCoreTasksDbContext aspNetCoreNTierDbContext)
    {
        _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _aspNetCoreNTierDbContext.AddAsync(entity);

        return entity;
    }

    public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entity)
    {
        await _aspNetCoreNTierDbContext.AddRangeAsync(entity);

        return entity;
    }

    public async TH.Task DeleteAsync(TEntity entity)
    {
        _ = _aspNetCoreNTierDbContext.Remove(entity);
    }

    public async Task<TEntity> GetAsync(
        Expression<Func<TEntity, bool>> filter = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _aspNetCoreNTierDbContext
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(filter, cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>> filter = null,
        CancellationToken cancellationToken = default
    )
    {
        return await (
            filter == null
                ? _aspNetCoreNTierDbContext.Set<TEntity>().ToListAsync(cancellationToken)
                : _aspNetCoreNTierDbContext
                    .Set<TEntity>()
                    .Where(filter)
                    .ToListAsync(cancellationToken)
        );
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _ = _aspNetCoreNTierDbContext.Update(entity);

        return entity;
    }

    public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entity)
    {
        _aspNetCoreNTierDbContext.UpdateRange(entity);

        return entity;
    }
}
