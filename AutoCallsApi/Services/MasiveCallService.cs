using AutoCallsApi.Data;
using AutoCallsApi.DTOs;
using AutoCallsApi.Helpers;
using AutoCallsApi.Models;
using EventSocketLibrary.ClientESL;
using Microsoft.AspNetCore.Mvc;

namespace AutoCallsApi.Services;

public class MasiveCallService
{
    private readonly IRepository<MasiveCall> _masiveCallRepository;
    private readonly IRepository<Number> _numberRepository;
    private readonly IAudioReproducer _audioReproducer;
    
    public MasiveCallService(IRepository<MasiveCall> masiveCallRepository, IAudioReproducer clientESL, IRepository<Number> numberRepository)
    {
        _masiveCallRepository = masiveCallRepository;
        _audioReproducer = clientESL;
        _numberRepository = numberRepository;
    }  

    public async Task<ActionResult<List<MasiveCall>>> GetMasiveCallsAsync()
    {
        return await _masiveCallRepository.GetAllAsync();
    }

    public async Task<MasiveCall> MakeMasiveCallAsync(MasiveCall masiveCall)
    {
        foreach (Call call in masiveCall.Calls)
        {
            Number number = await _numberRepository.GetByIdAsync(call.NumberId);
            call.Number = number;

            string response = _audioReproducer.Reproduce(call.Number.NumberValue, "Route...WIP");

            call.Result = response.StartsWith("+OK")
                ? CallResult.OK.ToString() 
                : CallResult.ERR.ToString();
        }

        return await _masiveCallRepository.SaveAsync(masiveCall);
    }
}