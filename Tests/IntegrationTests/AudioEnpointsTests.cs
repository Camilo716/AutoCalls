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
}