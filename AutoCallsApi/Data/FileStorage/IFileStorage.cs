namespace AutoCallsApi.Data.FileStorage;

public interface IFileStorage
{
    Task<StorageUrl> SaveFile(byte[] content, string extension, string container, string contentType);
    Task<StorageUrl> EditFile(byte[] content, string extension, string container, string route, string contentType);
    Task DeleteFile(string container, string route);
}