
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

    public async Task<string> SaveFile(byte[] content, string extension, string container, string contentType)
    {
        string fileName = $"{Guid.NewGuid()}{extension}";
    
        string folder = Path.Combine(_webHostEnv.WebRootPath, container);
        if(!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        string route = Path.Combine(folder, fileName);
        await File.WriteAllBytesAsync(route, content);

        HttpRequest requestContextAccessor = _httpContextAccessor.HttpContext.Request;
        string baseUrl = $"{requestContextAccessor.Scheme}://{requestContextAccessor.Host}";
        string urlForDatbase = Path.Combine(baseUrl, container, fileName).Replace("\\", "/");
        return urlForDatbase;
    }

    public Task<string> EditFile(byte[] content, string extension, string container, string route, string contentType)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteFile(string container, string route)
    {
        throw new NotImplementedException();
    }
}