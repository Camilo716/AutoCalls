using System.ComponentModel.DataAnnotations;

namespace AutoCallsApi.Helpers;

public enum CallResult
{
    [Display(Name = "+OK")]
    OK,
    [Display(Name = "-ERR")]
    ERR,
}