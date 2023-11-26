
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

    internal async Task<Audio> InsertAudioAsync(IFormFile audioFile)
    {
        using var memoryStream = new MemoryStream();
        await audioFile.CopyToAsync(memoryStream);
        byte[] audioData = memoryStream.ToArray();

        string extension = Path.GetExtension(audioFile.FileName);

        StorageUrl storageUrl = await _fileStorage.SaveFile(
                audioData, extension, _container, audioFile.ContentType);
        var audioEntity = new Audio
        {
            AudioUrl = storageUrl.Route 
        };

        return await _repository.SaveAsync(audioEntity);
    }
}