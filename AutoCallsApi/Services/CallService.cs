using AutoCallsApi.Data;
using AutoCallsApi.Models;

namespace AutoCallsApi.Services;

public class CallService
{
    private readonly IRepository<Call> _repository;
    
    public CallService(IRepository<Call> repository)
    {
        _repository = repository;
    }  

    public async Task<Call> PostCallAsync(Call call)
    {
        return await _repository.SaveAsync(call);
    }
}