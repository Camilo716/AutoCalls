using System.Net;
using IntegrationTests.Helpers.ModelUtilities;

namespace IntegrationTests;

// "Audio" enpoints tests
public partial class EnpointsTests
{
    [Theory]
    [InlineData("../../../Helpers/Audios/ValidFiles/testing-audio.mp3", "testing-audio.mp3")]
    [InlineData("../../../Helpers/Audios/ValidFiles/testing-audio.wav", "testing-audio.wav")]
    public async Task ClientPostValidAudio_ReturnSuccessTest(string fileRoute, string fileName)
    {
        var client = _factory.CreateClient();
        HttpContent audio = AudioUtilities.GetAudioHttpContent(fileRoute, fileName);

        HttpResponseMessage response = await client.PostAsync("/api/audio", audio);

        response.EnsureSuccessStatusCode();
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
    public async Task ClientPostInvalidFile_ReturnBadRequestTest(string fileRoute, string fileName)
    {
        var client = _factory.CreateClient();
        HttpContent audio = AudioUtilities.GetAudioHttpContent(fileRoute, fileName);
        
        HttpResponseMessage response = await client.PostAsync("/api/audio", audio);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}