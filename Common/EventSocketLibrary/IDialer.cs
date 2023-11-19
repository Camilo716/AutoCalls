namespace EventSocketLibrary;

public interface IDialer
{
    string Call(string number, string args = "");
}