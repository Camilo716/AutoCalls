using AutoCallsApi.Data;
using AutoCallsApi.Models;

namespace AutoCallsApi.Services;

public class NumberService
{
    private readonly IRepository<Number> _repository;

    public NumberService(IRepository<Number> repository)
    {
        _repository = repository;
    }

    public async Task<List<Number>> GetNumbersAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Number> InsertNumberAsync(Number number)
    {
        return await _repository.SaveAsync(number);
    }
}