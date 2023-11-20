using AutoCallsApi.Services.AudioPlayer;

namespace IntegrationTests.Helpers.ESL;

public class DumbAudioPlayer : IPlayableAudio
{
    public string PlayAudio(string number, string route)
    {
        return "+OK dd0b249c-2e56-43e0-abad-a716220a824e";
    }
}