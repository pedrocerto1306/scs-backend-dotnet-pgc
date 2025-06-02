namespace sics_webapi.Models.Interfaces;

public interface IS3StorageService
{
    Task<string> UploadFileAsync(string key, Stream content, string contentType);
}