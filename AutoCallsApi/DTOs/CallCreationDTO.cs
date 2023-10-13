using System.ComponentModel.DataAnnotations;

namespace AutoCallsApi.DTOs;

public class CallCreationDTO
{
    [Required]
    public IEnumerable<int> NumbersIds { get; set; }
    [Required]
    public int AudioId { get; set; }
}