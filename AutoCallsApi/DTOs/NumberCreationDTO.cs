using System.ComponentModel.DataAnnotations;

namespace AutoCallsApi.DTOs;

public class NumberCreationDTO
{
    [Required]
    public string NumberValue { get; set; }
}