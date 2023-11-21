using System.Net.Http.Headers;
using AutoCallsApi.Models;
using Microsoft.AspNetCore.Http;

namespace IntegrationTests.Helpers;

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