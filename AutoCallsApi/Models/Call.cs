using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoCallsApi.Helpers;

namespace AutoCallsApi.Models;

public class Call : IId
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public CallResult? Result { get; set; }

    [Required]
    public int NumberId { get; set; }
    public Number Number { get; set; }

    [Required]
    public int AudioId { get; set; }
    public Audio Audio { get; set; }
}