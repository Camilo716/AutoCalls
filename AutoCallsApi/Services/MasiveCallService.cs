using AutoCallsApi.Data;
using AutoCallsApi.Models;
using EventSocketLibrary.ClientESL;

namespace AutoCallsApi.Services;

public class MasiveCallService
{
    private readonly IRepository<MasiveCall> _repository;
    private readonly IClientESL _clientESL;
    
    public MasiveCallService(IRepository<MasiveCall> repository, IClientESL clientESL)
    {
        _repository = repository;
        _clientESL = clientESL;
    }  

    public async Task<MasiveCall> PostMasiveCallAsync(MasiveCall call)
    {
        return await _repository.SaveAsync(call);
    }
}