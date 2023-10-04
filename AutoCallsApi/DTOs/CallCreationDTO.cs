using System.ComponentModel.DataAnnotations;

namespace AutoCallsApi.DTOs;

public class CallCreationDTO
{
    [Required]
    public int NumberId { get; set; }
    [Required]
    public int AudioId { get; set; }
}