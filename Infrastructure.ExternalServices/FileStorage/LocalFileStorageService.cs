using Application.Services.Interfaces;

namespace Infrastructure.ExternalServices.FileStorage;

public class LocalFileStorageService(string baseDirectory) : IFileStorageService
{
    private readonly string _baseDirectory = baseDirectory;

    public async Task SaveFile(string path, Stream data)
    {
        var fullPath = Path.Combine(_baseDirectory, path);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

        await using var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
        await data.CopyToAsync(fileStream);
    }

    public async Task DeleteFile(string path)
    {
        await Task.Run(() =>
        {
            var fullPath = Path.Combine(_baseDirectory, path);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        });
    }

    public async Task GetFile(string path, Stream data)
    {
        var fullPath = Path.Combine(_baseDirectory, path);
        await using var fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
        await fileStream.CopyToAsync(data);
    }
}