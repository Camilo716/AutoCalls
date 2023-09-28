using AutoCallsApi.Models;
using AutoCallsApi.Services;
using AutoCallsApi.Validators.FileValidators;
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
        var validExtensions = new string[] { ".mp3" };
        if (!FileExtensionValidator.IsValid(audioFile, validExtensions))
        {
            return BadRequest(
                $"{audioFile.FileName} hasn't valid extension ({validExtensions.ToString()})");
        }

        Audio audioPosted = await _audioService.PostAudioAsync(audioFile);
        return Ok(audioPosted);
    }
}