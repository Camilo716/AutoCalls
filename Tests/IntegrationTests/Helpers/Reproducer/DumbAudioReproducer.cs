using AutoCallsApi.Services.Reproducer;

namespace IntegrationTests.Helpers.ESL;

public class DumbAudioReproducer : IAudioReproducer
{
    public string Reproduce(string number, string route)
    {
        return "+OK dd0b249c-2e56-43e0-abad-a716220a824e";
    }
}