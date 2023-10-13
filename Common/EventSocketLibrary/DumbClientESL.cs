namespace EventSocketLibrary.ClientESL;

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

    public string ApiCommand(string args)
    {
        throw new NotImplementedException();
    }
}