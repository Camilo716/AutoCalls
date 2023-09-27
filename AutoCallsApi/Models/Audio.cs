using System.ComponentModel.DataAnnotations;

namespace AutoCallsApi.Models;

public class Audio : IId
{
    public int Id { get; set ; }
    [Required]
    public byte[] AudioData { get; set; }
}