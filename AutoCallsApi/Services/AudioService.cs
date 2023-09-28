
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

    internal async Task<Audio> PostAudioAsync(IFormFile audioFile)
    {
        using var memoryStream = new MemoryStream();
        await audioFile.CopyToAsync(memoryStream);
        byte[] audioData = memoryStream.ToArray(); 

        return await _repository.SaveAsync(new Audio {AudioData = audioData});
    }
}