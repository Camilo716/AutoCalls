
using AutoCallsApi.Data;
using AutoCallsApi.Models;

namespace AutoCallsApi.Services;

public class AudioService
{
    private readonly IRepository<Audio> _repository;

    public AudioService(IRepository<Audio> repository)
    {
        _repository = repository;
    }

    internal async Task<Audio> PostAudioAsync(Audio audio)
    {
        return await _repository.SaveAsync(audio);
    }
}