using EventSocketLibrary;
using EventSocketLibrary.ClientESL;

namespace AutoCallsApi.Services.Reproducer;

public class FreeswitchAudioPlayer : IAudioReproducer
{
    private readonly IDialer _dialer;

    public FreeswitchAudioPlayer(IDialer dialer)
    {
        _dialer = dialer;
    }

    public string Reproduce(string number, string audioRoute)
    {
        return _dialer.Call(number, $"&playback({audioRoute}");
    }
}