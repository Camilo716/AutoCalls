using AutoCallsApi.Controllers;
using AutoCallsApi.Models;
using AutoCallsApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests;

public class AudioControllerValidationsTests
{
    private readonly AudioController _audioController;

    public AudioControllerValidationsTests()
    {
        var audioServiceMock = new AudioService(null, null);
        _audioController = new AudioController(audioServiceMock);
    }

    [Theory]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.jpg", "invalidExtension.jpg")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.jpeg", "invalidExtension.jpeg")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.png", "invalidExtension.png")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.txt", "invalidExtension.txt")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.pdf", "invalidExtension.pdf")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.doc", "invalidExtension.doc")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.zip", "invalidExtension.zip")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.rar", "invalidExtension.rar")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.exe", "invalidExtension.exe")]
    public async Task InvalidFileReturnBadRequestTest(string fileRoute, string fileName)
    {
        IFormFile audio = GetAudioFormFile(fileRoute, fileName);
        
        ActionResult<Audio> response = await _audioController.PostAsync(audio);

        var objectResult = Assert.IsType<BadRequestObjectResult>(response.Result);
        var statusCode = objectResult.StatusCode;
        Assert.Equal(StatusCodes.Status400BadRequest, statusCode);
    }

    internal static IFormFile GetAudioFormFile(string audioRoute, string fileName)
    {
        byte[] audioBytes = File.ReadAllBytes(audioRoute);

        var stream = new MemoryStream(audioBytes);
        var formFile = new FormFile(stream, 0, audioBytes.Length, "audioFile", fileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = "audio/mpeg"
        };

        return formFile;
    }
}