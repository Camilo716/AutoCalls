using System.ComponentModel.DataAnnotations;

namespace AutoCallsApi.Validators.FileValidators;

public class FileExtensionValidator
{
    private readonly string[] ValidExtensions;

    public FileExtensionValidator(string[] validExtensions)
    {
        ValidExtensions = validExtensions;
    } 
}