using EventSocketLibrary.ClientESL;

namespace EventSocketLibraryTests;

public class ClientEslTests: IDisposable
{
    private const string HOST = "172.16.238.10";
    private const int PORT = 8020;
    private ClientESL _client;

    public ClientEslTests()
    {
        _client = new ClientESL(HOST, PORT);
        _client.Connect();
    }

    [Fact]
    public void SuccesfullAuthenticationTest()
    {
        string password = "ClueCon";

        string authResponse = _client.Authenticate(password);

        Assert.Equal("+OK accepted", authResponse);
    }

    [Fact]
    public void FailedAuthenticationTest()
    {
        string password = "InvPass";

        string authResponse = _client.Authenticate(password);

        Assert.Equal("-ERR invalid", authResponse);
    }

    [Fact]
    public void ApiUptimeTest()
    {
        _client.Authenticate("ClueCon");

        int uptimeResponse = int.Parse(_client.ApiCommand("uptime"));

        bool timeIsRunningAndResponseIsANumber = uptimeResponse > 0;
        Assert.True(timeIsRunningAndResponseIsANumber);
    }

    public void Dispose()
    {
        _client.CloseConnection();
    }
}