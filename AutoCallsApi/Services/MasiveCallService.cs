using AutoCallsApi.Data;
using AutoCallsApi.DTOs;
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

    public async Task<MasiveCall> PostMasiveCallAsync(MasiveCall masiveCall)
    {
        _clientESL.Connect();
        _clientESL.Authenticate("ClueCon");


        foreach (Call call in masiveCall.Calls)
        {
            Number number = call.Number;
        }      
    
        return await _repository.SaveAsync(masiveCall);
    }
}