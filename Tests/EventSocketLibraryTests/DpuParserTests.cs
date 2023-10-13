using EventSocketLibrary.Util.Util;

namespace EventSocketLibraryTests;

public class DpuParserTests
{
    [Fact]
    public void GetContentLenghtTest()
    {
        string dpu =
        "Content-Type: api/response\n" +
        "Content-Length: 43\n\n";
        string key = "Content-Length";

        string contentLenght = DpuParser.GetLineValueFromKey(dpu, key);

        Assert.Equal("43", contentLenght);
    }

    [Fact]
    public void GetReplyTextTest()
    {
        string dpu =
        "Content-Type: command/reply\n"+
        "Reply-Text: -ERR invalid\n\n";
        string key = "Reply-Text";

        string replyText = DpuParser.GetLineValueFromKey(dpu, key);
        Assert.Equal("-ERR invalid", replyText);
    }
}