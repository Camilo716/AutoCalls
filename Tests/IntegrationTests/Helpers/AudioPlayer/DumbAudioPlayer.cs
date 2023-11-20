using AutoCallsApi.Helpers;
using AutoCallsApi.Services.AudioPlayer;

namespace IntegrationTests.Helpers.ESL;

public class DumbAudioPlayer : IPlayableAudio
{
    public CallResult PlayAudio(string number, string route)
    {
        return CallResult.OK;
    }
}