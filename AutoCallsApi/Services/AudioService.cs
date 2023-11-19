
using AutoCallsApi.Data;
using AutoCallsApi.Data.FileStorage;
using AutoCallsApi.Models;

namespace AutoCallsApi.Services;

public class AudioService
{
    private readonly IRepository<Audio> _repository;
    private readonly IFileStorage _fileStorage;
    private const string _container = "audios";

    public AudioService(IRepository<Audio> repository, IFileStorage fileStorage)
    {
        _repository = repository;
        _fileStorage = fileStorage;
    }

    internal async Task<Audio> PostAudioAsync(IFormFile audioFile)
    {
        using var memoryStream = new MemoryStream();
        await audioFile.CopyToAsync(memoryStream);
        byte[] audioData = memoryStream.ToArray();

        string extension = Path.GetExtension(audioFile.FileName);

        var audioEntity = new Audio
        {
            AudioUrl = await _fileStorage.SaveFile(
                audioData, extension, _container, audioFile.ContentType)
        };

        return await _repository.SaveAsync(audioEntity);
    }
}