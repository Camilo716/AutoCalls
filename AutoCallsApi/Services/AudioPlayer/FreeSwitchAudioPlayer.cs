using AutoCallsApi.Helpers;
using EventSocketLibrary;

namespace AutoCallsApi.Services.AudioPlayer;

public class FreeswitchAudioPlayer : IPlayableAudio
{
    private readonly IDialer _dialer;

    public FreeswitchAudioPlayer(IDialer dialer)
    {
        _dialer = dialer;
    }

    public CallResult PlayAudio(string number, string audioRoute)
    {
        string response = _dialer.Call(number, $"&playback({audioRoute}");

        return response.StartsWith("+OK")
            ? CallResult.OK
            : CallResult.ERR;
    }
}