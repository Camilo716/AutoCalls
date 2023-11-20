using AutoCallsApi.Services.AudioPlayer;
using Microsoft.Extensions.Configuration;

namespace IntegrationTests.Helpers.ESL;

public class DumbAudioPlayerFactory : IAudioPlayerFactory
{
    public IPlayableAudio Initialize(IConfiguration config)
    {
        return new DumbAudioPlayer();
    }
}