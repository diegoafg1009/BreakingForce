namespace Application.Utils;

public static class MimeMapping
{
    public static string GetMime(string extension)
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

    public static string GetExtension(string mimeType)
    {
        return mimeType.ToLowerInvariant() switch
        {
            "image/png" => ".png",
            "image/jpeg" => ".jpg",
            "image/gif" => ".gif",
            "image/bmp" => ".bmp",
            "image/tiff" => ".tiff",
            "image/svg+xml" => ".svg",
            "image/webp" => ".webp",
            "image/x-icon" => ".ico",
            "image/apng" => ".apng",
            "image/avif" => ".avif",
            "image/flif" => ".flif",
            "image/heif" => ".heif",
            "image/heic" => ".heic",
            "image/jp2" => ".jp2",
            "image/jxr" => ".jxr",
            "image/vnd.ms-photo" => ".wdp",
            "image/bpg" => ".bpg",
            "image/x-canon-cr2" => ".cr2",
            "image/x-olympus-orf" => ".orf",
            "image/x-sony-arw" => ".arw",
            "image/x-adobe-dng" => ".dng",
            "image/x-nikon-nef" => ".nef",
            "image/x-panasonic-rw2" => ".rw2",
            "image/x-fuji-raf" => ".raf",
            "image/x-pentax-pef" => ".pef",
            "image/x-samsung-srw" => ".srw",
            "image/x-sigma-x3f" => ".x3f",
            "video/webm" => ".webm",
            "video/x-matroska" => ".mkv",
            "video/x-flv" => ".flv",
            "video/x-ms-vob" => ".vob",
            "video/ogg" => ".ogv",
            "video/x-dirac" => ".drc",
            "video/gif" => ".gifv",
            _ => string.Empty
        };
    }

    public static string GetMimeByFileName(string fileName)
    {
        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        return GetMime(extension);
    }
}