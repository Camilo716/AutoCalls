using System.ComponentModel.DataAnnotations;

namespace AutoCallsApi.DTOs;

public class NumberCreationDTO
{
    [Required]
    public int NumberValue{ get; set; }
}