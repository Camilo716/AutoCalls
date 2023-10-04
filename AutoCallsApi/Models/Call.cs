using System.ComponentModel.DataAnnotations;

namespace AutoCallsApi.Models;

public class Call : IId
{
    public int Id { get; set ; }
    [Required]
    public int NumberId { get; set; }
    [Required]
    public int AudioId { get; set; }
}