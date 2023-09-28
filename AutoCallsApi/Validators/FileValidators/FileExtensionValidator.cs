using System.ComponentModel.DataAnnotations;

namespace AutoCallsApi.Validators.FileValidators;

public static class FileExtensionValidator
{
    public static bool IsValid(IFormFile file, string[] validExtensions)
    {
        string fileExtension = Path.GetExtension(file.FileName).ToLower();
        bool IsvalidExtension = validExtensions.Contains(fileExtension);
        return IsvalidExtension;
    }
}