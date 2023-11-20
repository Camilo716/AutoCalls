using AutoCallsApi.Helpers;

namespace AutoCallsApi.Services.AudioPlayer;

public interface IPlayableAudio
{
    CallResult PlayAudio(string number, string audioRoute);
}