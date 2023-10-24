using Microsoft.AspNetCore.Mvc;
using AutoCallsApi.Services;
using AutoCallsApi.Models;
using AutoCallsApi.DTOs;
using AutoMapper;

namespace AutoCallsApi.Controllers;

[ApiController]
[Route("/api/[Controller]")]
public class MasiveCallController: ControllerBase
{
    private readonly MasiveCallService _callService;
    private readonly IMapper _mapper;

    public MasiveCallController(MasiveCallService callService, IMapper mapper)
    {
        _callService = callService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<MasiveCall>>> GetAsync()
    {
        return await _callService.GetMasiveCallsAsync();
    }

    [HttpPost]
    public async Task<ActionResult<MasiveCall>> PostAsync([FromBody] MasiveCallCreationDTO masiveCallCreationDTO)
    {
        MasiveCall call = _mapper.Map<MasiveCall>(masiveCallCreationDTO);
        MasiveCall callPosted = await _callService.PostMasiveCallAsync(call);
        return Ok(callPosted);
    }
}