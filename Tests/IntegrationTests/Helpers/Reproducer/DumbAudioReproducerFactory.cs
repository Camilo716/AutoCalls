using AutoCallsApi.Services.Reproducer;
using EventSocketLibrary.ClientESL;
using Microsoft.Extensions.Configuration;

namespace IntegrationTests.Helpers.ESL;

public class DumbAudioReproducerFactory : IAudioReproducerFactory
{
    public IAudioReproducer Initialize(IConfiguration config)
    {
        return new DumbAudioReproducer();
    }
}