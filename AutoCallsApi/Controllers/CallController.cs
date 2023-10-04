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
    private readonly CallService _callService;
    private readonly IMapper _mapper;

    public CallController(CallService callService, IMapper mapper)
    {
        _callService = callService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<Call>> PostAsync([FromBody] CallCreationDTO callCreationDTO)
    {
        Call call = _mapper.Map<Call>(callCreationDTO);
        Call callPosted = await _callService.PostCallAsync(call);
        return Ok(callPosted);
    }
}