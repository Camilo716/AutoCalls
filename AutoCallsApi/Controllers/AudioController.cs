using AutoCallsApi.Models;
using AutoCallsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoCallsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AudioController : ControllerBase
{
    private readonly AudioService _audioService;

    public AudioController(AudioService audioService)
    {
        _audioService = audioService;
    }

    [HttpPost]
    public async Task<ActionResult<Audio>> PostAsync([FromForm] IFormFile audioFile)
    {
        using var memoryStream = new MemoryStream();
        await audioFile.CopyToAsync(memoryStream);
        byte[] audioData = memoryStream.ToArray(); 

        Audio audioPosted = await _audioService.PostAudioAsync(new Audio {AudioData = audioData});
        return Ok(audioPosted);
    }
}