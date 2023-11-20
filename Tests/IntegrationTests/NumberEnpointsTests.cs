namespace IntegrationTests;

// "Number" enpoints tests
public partial class EnpointsTests
{
    [Fact]
    public async Task ClientPostNewNumber_ReturnSuccessTest()
    {
        var client = _factory.CreateClient();
        HttpContent number = NumberUtilities.GetNumberHttpContent("321459789");

        HttpResponseMessage response = await client.PostAsync("/api/number", number);

        response.EnsureSuccessStatusCode();
    }
}