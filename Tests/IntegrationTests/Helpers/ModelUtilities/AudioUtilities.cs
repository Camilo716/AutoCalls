using System.Net.Http.Headers;

namespace IntegrationTests.Helpers.ModelUtilities;

internal static class AudioUtilities
{
    internal static HttpContent GetAudioHttpContent(string AudioRoute, string fileName)
    {
        byte[] audioBytes = File.ReadAllBytes(AudioRoute);
        var audioContent = new ByteArrayContent(audioBytes);
        audioContent.Headers.ContentType = new MediaTypeHeaderValue("audio/mpeg");

        var content = new MultipartFormDataContent
        {
            { audioContent, "audioFile", fileName }
        };

        return content;
    }
}