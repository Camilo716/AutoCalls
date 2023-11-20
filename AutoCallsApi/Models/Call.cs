using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCallsApi.Models;

public class Call : IId
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Result { get; set; }

    [Required]
    public int NumberId { get; set; }
    [ForeignKey("NumberId")]
    public Number Number { get; set; }
    [Required]
    public int AudioId { get; set; }
    public Audio Audio { get; set; }
}