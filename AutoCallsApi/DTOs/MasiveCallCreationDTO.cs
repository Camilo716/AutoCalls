using System.ComponentModel.DataAnnotations;
using AutoCallsApi.Models;

namespace AutoCallsApi.DTOs;

public class MasiveCallCreationDTO
{
    [Required]
    public ICollection<int> IdsNumbersToCall { get; set; }
    [Required]
    public int AudioId { get; set; }
}