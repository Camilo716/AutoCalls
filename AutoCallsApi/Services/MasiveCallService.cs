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
    private readonly IRepository<Audio> _audioRepository;
    private readonly IAudioReproducer _audioReproducer;
    
    public MasiveCallService(
        IRepository<MasiveCall> masiveCallRepository,
        IAudioReproducer audioReproducer, 
        IRepository<Number> numberRepository,
        IRepository<Audio> audioRepository)
    {
        _masiveCallRepository = masiveCallRepository;
        _audioReproducer = audioReproducer;
        _numberRepository = numberRepository;
        _audioRepository = audioRepository;
    }  

    public async Task<ActionResult<List<MasiveCall>>> GetMasiveCallsAsync()
    {
        return await _masiveCallRepository.GetAllAsync();
    }

    public async Task<MasiveCall> MakeMasiveCallAsync(MasiveCall masiveCall)
    {
        Audio audio = await _audioRepository.GetByIdAsync(masiveCall.AudioId);
        masiveCall.Audio = audio;

        foreach (Call call in masiveCall.Calls)
        {
            Number number = await _numberRepository.GetByIdAsync(call.NumberId);
            call.Number = number;

            string response = _audioReproducer.Reproduce(call.Number.NumberValue, masiveCall.Audio.AudioUrl);

            call.Result = response.StartsWith("+OK")
                ? CallResult.OK.ToString() 
                : CallResult.ERR.ToString();
        }

        return await _masiveCallRepository.SaveAsync(masiveCall);
    }
}