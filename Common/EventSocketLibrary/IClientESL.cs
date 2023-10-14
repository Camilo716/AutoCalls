namespace EventSocketLibrary.ClientESL;

public interface IClientESL
{
    void Connect();
    void CloseConnection();
    string Authenticate(string password);
    string MasiveCall(string number, string args = "");
}