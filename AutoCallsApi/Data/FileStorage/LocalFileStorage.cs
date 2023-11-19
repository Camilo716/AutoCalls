
namespace AutoCallsApi.Data.FileStorage;

public class LocalFileStorage : IFileStorage
{
    private readonly IWebHostEnvironment _webHostEnv;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LocalFileStorage(IWebHostEnvironment webHostEnv, IHttpContextAccessor httpContextAccessor)
    {
        _webHostEnv = webHostEnv;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<StorageUrl> SaveFile(byte[] content, string extension, string container, string contentType)
    {
        string fileName = $"{Guid.NewGuid()}{extension}";
    
        string directory = Path.Combine(_webHostEnv.WebRootPath, container);
        if(!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        string route = Path.Combine(directory, fileName);
        await File.WriteAllBytesAsync(route, content);

        HttpRequest requestContextAccessor = _httpContextAccessor.HttpContext.Request;
        return new StorageUrl()
        {
            BaseUrl = $"{requestContextAccessor.Scheme}://{requestContextAccessor.Host}".Replace("\\", "/"),
            Route = Path.Combine(container, fileName)
        };
    }

    public async Task<StorageUrl> EditFile(byte[] content, string extension, string container, string route, string contentType)
    {
        await DeleteFile(route, container);
        return await SaveFile(content, extension, container, contentType);
    }

    public Task DeleteFile(string container, string route)
    {
        if (route == null)
            throw new ArgumentNullException();

        string fileName = Path.GetFileName(route);
        string directoryFile = Path.Combine(_webHostEnv.WebRootPath, container, fileName);
        if(!File.Exists(directoryFile))
            throw new FileNotFoundException();

        File.Delete(directoryFile);
        return Task.FromResult(0);
    }
}