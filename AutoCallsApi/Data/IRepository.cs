using AutoCallsApi.Models;

namespace AutoCallsApi.Data;

public interface IRepository<TEntity> where TEntity : class, IId
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> SaveAsync(TEntity entity);
}