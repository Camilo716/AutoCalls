namespace AutoCallsApi.Services.AudioPlayer;

public interface IAudioPlayerFactory
{
    IPlayableAudio Initialize(IConfiguration config);
}