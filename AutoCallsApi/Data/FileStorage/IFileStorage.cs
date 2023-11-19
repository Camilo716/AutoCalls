namespace AutoCallsApi.Data.FileStorage;

public interface IFileStorage
{
    Task<string> SaveFile(byte[] content, string extension, string container, string contentType);
    Task<string> EditFile(byte[] content, string extension, string container, string route, string contentType);
    Task DeleteFile(string container, string route);
}