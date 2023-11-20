using EventSocketLibrary.ClientESL;

namespace AutoCallsApi.Services.AudioPlayer;

public class FreeSwitchAudioPlayerFactory : IAudioPlayerFactory
{
    public IPlayableAudio Initialize(IConfiguration config)
    {
        var fsClient = new ClientESL(
            config["FreeSwitchHost"]!,
            Convert.ToInt32(config["FreeSwitchPort"])
        );

        fsClient.Connect();
        fsClient.Authenticate("ClueCon");

        var freeswitchAudioPlayer = new FreeswitchAudioPlayer(fsClient);
        return freeswitchAudioPlayer;
    }
}