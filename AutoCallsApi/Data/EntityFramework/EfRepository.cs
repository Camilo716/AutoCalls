
using AutoCallsApi.Models;
using Microsoft.EntityFrameworkCore;

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
}