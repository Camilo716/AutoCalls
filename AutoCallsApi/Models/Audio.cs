using System.ComponentModel.DataAnnotations;
using AutoCallsApi.Data.FileStorage;

namespace AutoCallsApi.Models;

public class Audio : IId
{
    public int Id { get; set ; }
    [Required]
    public string AudioUrl { get; set;}
}