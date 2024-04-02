namespace BreakingForce.API.Utils;

public static class MimeTypesExtensions
{
    public static string GetByExtension(string extension)
    {
        return extension.ToLowerInvariant() switch
        {
            ".png" => "image/png",
            ".jpg" => "image/jpeg",
            ".jpeg" => "image/jpeg",
            ".jpe" => "image/jpeg",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            ".tiff" => "image/tiff",
            ".tif" => "image/tiff",
            ".svg" => "image/svg+xml",
            ".webp" => "image/webp",
            ".ico" => "image/x-icon",
            ".cur" => "image/x-icon",
            ".apng" => "image/apng",
            ".avif" => "image/avif",
            ".flif" => "image/flif",
            ".heif" => "image/heif",
            ".heic" => "image/heic",
            ".jp2" => "image/jp2",
            ".jxr" => "image/jxr",
            ".wdp" => "image/vnd.ms-photo",
            ".hdp" => "image/vnd.ms-photo",
            ".bpg" => "image/bpg",
            ".br" => "image/webp",
            ".cr2" => "image/x-canon-cr2",
            ".orf" => "image/x-olympus-orf",
            ".arw" => "image/x-sony-arw",
            ".dng" => "image/x-adobe-dng",
            ".nef" => "image/x-nikon-nef",
            ".rw2" => "image/x-panasonic-rw2",
            ".raf" => "image/x-fuji-raf",
            ".pef" => "image/x-pentax-pef",
            ".srw" => "image/x-samsung-srw",
            ".x3f" => "image/x-sigma-x3f",
            ".webm" => "video/webm",
            ".mkv" => "video/x-matroska",
            ".flv" => "video/x-flv",
            ".vob" => "video/x-ms-vob",
            ".ogv" => "video/ogg",
            ".drc" => "video/x-dirac",
            ".gifv" => "video/gif",
            _ => "application/octet-stream"
        };
    }

    public static string GetByFileName(string fileName)
    {
        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        return GetByExtension(extension);
    }
}