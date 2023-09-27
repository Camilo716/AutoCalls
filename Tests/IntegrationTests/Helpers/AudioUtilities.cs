using System.Net.Http.Headers;

namespace Tests.IntegrationTests.Helpers;

internal static class AudioUtilities
{
    internal static HttpContent GetAudioHttpContent(string AudioRoute)
    {
        byte[] audioBytes = File.ReadAllBytes(AudioRoute);
        var audioContent = new ByteArrayContent(audioBytes);
        audioContent.Headers.ContentType = new MediaTypeHeaderValue("audio/mpeg");

        var content = new MultipartFormDataContent
        {
            { audioContent, "audioFile", "audio.mp3" }
        };

        return content;
    }
}