using AutoCallsApi.Data;
using AutoCallsApi.DTOs;
using AutoCallsApi.Helpers;
using AutoCallsApi.Models;
using EventSocketLibrary.ClientESL;

namespace AutoCallsApi.Services;

public class MasiveCallService
{
    private readonly IRepository<MasiveCall> _masiveCallRepository;
    private readonly IRepository<Number> _numberRepository;
    private readonly IClientESL _clientESL;
    
    public MasiveCallService(IRepository<MasiveCall> masiveCallRepository, IClientESL clientESL, IRepository<Number> numberRepository)
    {
        _masiveCallRepository = masiveCallRepository;
        _clientESL = clientESL;
        _numberRepository = numberRepository;
    }  

    public async Task<MasiveCall> PostMasiveCallAsync(MasiveCall masiveCall)
    {
        _clientESL.Connect();
        _clientESL.Authenticate("ClueCon");

        foreach (Call call in masiveCall.Calls)
        {
            Number number = await _numberRepository.GetByIdAsync(call.NumberId);
            call.Number = number;

            string response = _clientESL.Call(call.Number.NumberValue, "&echo()");

            call.Result = response.StartsWith("+OK")
                ? CallResult.OK 
                : CallResult.ERR;
        }
    
        return await _masiveCallRepository.SaveAsync(masiveCall);
    }
}