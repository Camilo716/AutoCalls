using EventSocketLibrary;

namespace AutoCallsApi.Services.AudioPlayer;

public class FreeswitchAudioPlayer : IPlayableAudio
{
    private readonly IDialer _dialer;

    public FreeswitchAudioPlayer(IDialer dialer)
    {
        _dialer = dialer;
    }

    public string PlayAudio(string number, string audioRoute)
    {
        return _dialer.Call(number, $"&playback({audioRoute}");
    }
}