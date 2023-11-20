namespace AutoCallsApi.Services.AudioPlayer;

public interface IPlayableAudio
{
    string PlayAudio(string number, string audioRoute);
}