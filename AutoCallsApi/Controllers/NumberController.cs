using Microsoft.AspNetCore.Mvc;
using AutoCallsApi.Services;
using AutoCallsApi.Models;

namespace AutoCallsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class NumberController : ControllerBase
{
    private readonly NumberService _numberService;

    public NumberController(NumberService numberService)
    {
        _numberService = numberService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Number>>> GetAsync()
    {
        List<Number> numbers = await _numberService.GetNumbersAsync(); 
        return Ok(numbers);
    }
}