using EventSocketLibrary.ClientESL;

namespace AutoCallsApi.Services.Reproducer;

public interface IAudioReproducerFactory
{
    IAudioReproducer Initialize(IConfiguration config);
}