using Microsoft.AspNetCore.Mvc;
using AutoCallsApi.Services;
using AutoCallsApi.Models;
using AutoCallsApi.DTOs;
using AutoMapper;

namespace AutoCallsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class NumberController : ControllerBase
{
    private readonly NumberService _numberService;
    public readonly IMapper _mapper;

    public NumberController(NumberService numberService, IMapper mapper)
    {
        _numberService = numberService;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<List<Number>>> GetAsync()
    {
        List<Number> numbers = await _numberService.GetNumbersAsync(); 
        return Ok(numbers);
    }

    [HttpPost]
    public async Task<ActionResult<Number>> PostAsync([FromBody] NumberCreationDTO numberDto)
    {
        Number number = _mapper.Map<Number>(numberDto);
        Number numberPosted = await _numberService.PostNumberAsync(number);
        return Ok(numberPosted);
    }
}