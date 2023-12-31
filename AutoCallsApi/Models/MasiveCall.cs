using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCallsApi.Models;

public class MasiveCall : IId
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set ; }

    [Required]
    public ICollection<Call> Calls { get; set; }

    [Required]
    public int AudioId { get; set; }
    public Audio Audio { get; set; }
}