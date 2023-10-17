
using AutoCallsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AutoCallsApi.Data.EntityFramework;

public class EfRepository<TEntity>: IRepository<TEntity> where TEntity: class, IId 
{
    private readonly EfApplicationDbContext _dbContext;
    private readonly DbSet<TEntity> _entities;

    public EfRepository(EfApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = _dbContext.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        TEntity? entity = await _dbContext.FindAsync<TEntity>(id)!;

        return entity ?? throw new KeyNotFoundException($"{typeof(TEntity)} with id {id} not found");
    }

    public async Task<TEntity> SaveAsync(TEntity entity)
    {
        EntityEntry<TEntity> entityCreated = await _dbContext.AddAsync(entity);
        _dbContext.SaveChanges();
        return entityCreated.Entity;
    }
}