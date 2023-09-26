using System.ComponentModel.DataAnnotations;

namespace AutoCallsApi.Models;

public class Number : IId
{
    public int Id { get; set; }
    [Required]
    public int NumberValue{ get; set; }
}