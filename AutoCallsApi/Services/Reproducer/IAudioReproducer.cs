namespace AutoCallsApi.Services.Reproducer;

public interface IAudioReproducer
{
    string Reproduce(string number, string audioRoute);
}