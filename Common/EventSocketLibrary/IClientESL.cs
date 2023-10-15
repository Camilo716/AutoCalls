namespace EventSocketLibrary.ClientESL;

public interface IClientESL
{
    void Connect();
    void CloseConnection();
    string Authenticate(string password);
    string Call(string number, string args = "");
}