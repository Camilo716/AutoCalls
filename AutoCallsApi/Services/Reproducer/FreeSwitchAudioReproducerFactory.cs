using EventSocketLibrary.ClientESL;

namespace AutoCallsApi.Services.Reproducer;

public class FreeSwitchAudioReproducerFactory : IAudioReproducerFactory
{
    public IAudioReproducer Initialize(IConfiguration config)
    {
        var caller = new ClientESL(
            config["FreeSwitchHost"]!,
            Convert.ToInt32(config["FreeSwitchPort"])
        );

        caller.Connect();
        caller.Authenticate("ClueCon");

        return caller;
    }
}