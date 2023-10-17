using System.ComponentModel.DataAnnotations;
using AutoCallsApi.Models;

namespace AutoCallsApi.DTOs;

public class MasiveCallCreationDTO
{
    [Required]
    public int[] IdsNumbersToCall { get; set; }
    [Required]
    public int AudioId { get; set; }
}