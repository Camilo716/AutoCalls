using Microsoft.AspNetCore.Mvc;
using AutoCallsApi.Services;
using AutoCallsApi.Models;
using AutoCallsApi.DTOs;
using AutoMapper;

namespace AutoCallsApi.Controllers;

[ApiController]
[Route("/api/[Controller]")]
public class CallController: ControllerBase
{
    private readonly MasiveCallService _callService;
    private readonly IMapper _mapper;

    public CallController(MasiveCallService callService, IMapper mapper)
    {
        _callService = callService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<MasiveCall>> PostAsync([FromBody] MasiveCallCreationDTO MasiveCallCreationDTO)
    {
        MasiveCall call = _mapper.Map<MasiveCall>(MasiveCallCreationDTO);
        MasiveCall callPosted = await _callService.PostMasiveCallAsync(call);
        return Ok(callPosted);
    }
}