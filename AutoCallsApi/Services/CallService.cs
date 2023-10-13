using AutoCallsApi.Data;
using AutoCallsApi.Models;
using EventSocketLibrary.ClientESL;

namespace AutoCallsApi.Services;

public class CallService
{
    private readonly IRepository<Call> _repository;
    private readonly IClientESL _clientESL;
    
    public CallService(IRepository<Call> repository, IClientESL clientESL)
    {
        _repository = repository;
        _clientESL = clientESL;
    }  

    public async Task<Call> PostCallAsync(Call call)
    {
        return await _repository.SaveAsync(call);
    }
}