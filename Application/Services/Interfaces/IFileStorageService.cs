namespace Application.Services.Interfaces;

public interface IFileStorageService
{
    Task SaveFile(string path, Stream data);
    Task DeleteFile(string path);
}