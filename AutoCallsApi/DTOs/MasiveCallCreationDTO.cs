using System.ComponentModel.DataAnnotations;

namespace AutoCallsApi.DTOs;

public class MasiveCallCreationDTO
{
    [Required]
    public ICollection<int> NumbersIds { get; set; }
    [Required]
    public int AudioId { get; set; }
}