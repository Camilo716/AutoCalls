using EventSocketLibrary.ClientESL;

namespace IntegrationTests.Helpers.ESL;

public class DumbClientESL : IClientESL
{
    public void Connect() { }
    public void CloseConnection() { }
    public string Authenticate(string password)
    {
        string successResponse =
        "Content-Type: command/reply\n"+
        "Reply-Text: +OK accepted";

        string errorResponse =
        "Content-Type: command/reply\n"+
        "Reply-Text: -ERR invalid";

        return password == "ClueCon" ? successResponse : errorResponse;  
    }

    public string MasiveCall(string number, string? args)
    {
        return "+OK dd0b249c-2e56-43e0-abad-a716220a824e";
    }
}